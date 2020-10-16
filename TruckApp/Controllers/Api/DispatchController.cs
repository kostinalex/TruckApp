using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TruckApp.Models;

namespace TruckApp.Controllers.Api
{
    [Authorize(Roles = RoleName.CanEnter)]
    public class DispatchController : ApiController
    {
        private ApplicationDbContext _context;
        public DispatchController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpGet]
        [Route("api/dispatch")]
        public IEnumerable<Dispatch> GetNonVoidDispatch()
        {
            return _context.Dispatches.Where(c => c.Void == false).ToList(); //
        }

        [HttpGet]
        [Route("api/getalldispatch")]
        public IEnumerable<Dispatch> GetAllDispatch()
        {
            return _context.Dispatches.ToList();
        }


        public IHttpActionResult Getdispatch(int id)
        {
            var dispatchToGet = _context.Dispatches.SingleOrDefault(c => c.Id == id);

            if (dispatchToGet == null)
                return NotFound();

            return Ok(dispatchToGet);
        }

        [HttpPost]
        [Route("api/dispatch")]
        [Authorize(Roles = RoleName.CanManageDispatchDriversAndOther)]
        public IHttpActionResult New(Dispatch dispatch)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.Dispatches.Add(dispatch);

            var userAction = new UserAction
            {
                UserName = User.Identity.Name,
                Action = "Dispatch was added. Dispatch name " + dispatch.Name,
                DateTime = DateTime.Now
            };
            _context.UserActions.Add(userAction);


            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + dispatch.Id), dispatch);
        }

        [HttpPut]
        [Authorize(Roles = RoleName.CanManageDispatchDriversAndOther)]
        public void Editdispatch(int id, Dispatch dispatch)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var dispatchToEdit = _context.Dispatches.SingleOrDefault(c => c.Id == id);

            dispatchToEdit.Name = dispatch.Name;
            dispatchToEdit.Void = dispatch.Void;

            var userAction = new UserAction
            {
                UserName = User.Identity.Name,
                Action = "Dispatch was edited. Dispatch name " + dispatch.Name,
                DateTime = DateTime.Now
            };
            _context.UserActions.Add(userAction);


            _context.SaveChanges();

        }

        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageDispatchDriversAndOther)]
        public void VoidDispatch(int id)
        {
            var dispatchToVoid = _context.Dispatches.SingleOrDefault(c => c.Id == id);

            if (dispatchToVoid == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            dispatchToVoid.Void = true;

            var userAction = new UserAction
            {
                UserName = User.Identity.Name,
                Action = "Dispatch was voided. Dispatch name " + dispatchToVoid.Name,
                DateTime = DateTime.Now
            };
            _context.UserActions.Add(userAction);


            _context.SaveChanges();

        }





        //[HttpDelete]
        //[Authorize(Roles = RoleName.CanManageDispatchDriversAndOther)]
        //public void Deletedispatch(int id)
        //{
        //    var dispatchToDelete = _context.Dispatches.SingleOrDefault(c => c.Id == id);

        //    if (dispatchToDelete == null)
        //        throw new HttpResponseException(HttpStatusCode.NotFound);

        //    _context.Dispatches.Remove(dispatchToDelete);

        //    var userAction = new UserAction
        //    {
        //        UserName = User.Identity.Name,
        //        Action = "Dispatch was deleted. Dispatch name " + dispatchToDelete.Name,
        //        DateTime = DateTime.Now
        //    };
        //    _context.UserActions.Add(userAction);


        //    _context.SaveChanges();

        //}
    }
}
