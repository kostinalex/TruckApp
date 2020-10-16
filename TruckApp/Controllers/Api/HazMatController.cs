using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TruckApp.Models;
using TruckApp.ViewModels;
using System.Data.Entity;

namespace TruckApp.Controllers.API
{
    [Authorize(Roles = RoleName.CanEnter)]
    public class HazMatController : ApiController
    {
        private ApplicationDbContext _context;
        public HazMatController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////


        public IEnumerable<HazMatStatus> GetHazmat()
        {
            return _context.HazMatStatuses.ToList();
        }


        public IHttpActionResult GetHazMat(int id)
        {
            var hazMatToGet = _context.HazMatStatuses.SingleOrDefault(c => c.Id == id);

            if (hazMatToGet == null)
                return NotFound();

            return Ok(hazMatToGet);
        }

        [HttpPost]
        [Authorize(Roles = RoleName.CanManageDispatchDriversAndOther)]
        public IHttpActionResult New(HazMatStatus hazMatStatus)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.HazMatStatuses.Add(hazMatStatus);


            var userAction = new UserAction
            {
                UserName = User.Identity.Name,
                Action = "HazMat was added. HazMat name " + hazMatStatus.Name,
                DateTime = DateTime.Now

            };
            _context.UserActions.Add(userAction);


            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + hazMatStatus.Id), hazMatStatus);
        }

        [HttpPut]
        [Authorize(Roles = RoleName.CanManageDispatchDriversAndOther)]
        public void EditHazMat(int id, HazMatStatus hazMatStatus)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var hazMatStatusToEdit = _context.HazMatStatuses.SingleOrDefault(c => c.Id == id);

            hazMatStatusToEdit.Name = hazMatStatus.Name;

            var userAction = new UserAction
            {
                UserName = User.Identity.Name,
                Action = "HazMat was edited. HazMat name " + hazMatStatus.Name,
                DateTime = DateTime.Now
            };
            _context.UserActions.Add(userAction);


            _context.SaveChanges();

        }

        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageDispatchDriversAndOther)]
        public void DeleteHazMat(int id)
        {
            var hazMatToDelete = _context.HazMatStatuses.SingleOrDefault(c => c.Id == id);

            if (hazMatToDelete == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.HazMatStatuses.Remove(hazMatToDelete);


            var userAction = new UserAction
            {
                UserName = User.Identity.Name,
                Action = "HazMat was deleted. HazMat name " + hazMatToDelete.Name,
                DateTime = DateTime.Now
            };
            _context.UserActions.Add(userAction);


            _context.SaveChanges();

        }
    }
}
