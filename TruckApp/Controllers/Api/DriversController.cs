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
    public class DriversController : ApiController
    {
        private ApplicationDbContext _context;
        public DriversController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// 





        [HttpGet]
        [Route("api/drivers")]
        public IEnumerable<Driver> GetNonVoidDrivers()       
        {
            return _context.Drivers.Where(c => c.Void == false).ToList();
        }

        [HttpGet]
        [Route("api/getalldrivers")]
        public IEnumerable<Driver> GetAllDrivers()
        {
            return _context.Drivers.ToList();
        }



        public IHttpActionResult GetDriver(int id)
        {
            var driverToGet = _context.Drivers.SingleOrDefault(c => c.Id == id);

            if (driverToGet == null)
                return NotFound();

            return Ok(driverToGet);
        }

        [HttpPost]
        [Route("api/drivers")]
        [Authorize(Roles = RoleName.CanManageDispatchDriversAndOther)]
        public IHttpActionResult New(Driver driver)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.Drivers.Add(driver);

            var userAction = new UserAction
            {
                UserName = User.Identity.Name,
                Action="New driver created. Driver name "+driver.Name,
                DateTime= DateTime.Now
            };
            _context.UserActions.Add(userAction);

            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + driver.Id), driver);
        }

        [HttpPut]
        [Authorize(Roles = RoleName.CanManageDispatchDriversAndOther)]
        public void EditDriver(int id, Driver driver)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var DriverToEdit = _context.Drivers.SingleOrDefault(c => c.Id == id);

            DriverToEdit.Name = driver.Name;
            DriverToEdit.Void = driver.Void;

            var userAction = new UserAction
            {
                UserName = User.Identity.Name,
                Action = "Driver was edited. Driver name "+driver.Name,
                DateTime = DateTime.Now
            };
            _context.UserActions.Add(userAction);


            _context.SaveChanges();

        }



        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageDispatchDriversAndOther)]
        public void DeleteDriver(int id)
        {
            var driverToVoid = _context.Drivers.SingleOrDefault(c => c.Id == id);

            if (driverToVoid == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);


            driverToVoid.Void = true;
            //_context.Drivers.Remove(driverToVoid);

            var userAction = new UserAction
            {
                UserName = User.Identity.Name,
                Action = "Driver was voided. Driver name " + driverToVoid.Name,
                DateTime = DateTime.Now
            };
            _context.UserActions.Add(userAction);
            _context.SaveChanges();

        }

        //[HttpDelete]
        //[Authorize(Roles = RoleName.CanManageDispatchDriversAndOther)]
        //public void DeleteDriver(int id)
        //{
        //    var driverToDelete = _context.Drivers.SingleOrDefault(c => c.Id == id);

        //    if (driverToDelete == null)
        //        throw new HttpResponseException(HttpStatusCode.NotFound);



        //    _context.Drivers.Remove(driverToDelete);

        //    var userAction = new UserAction
        //    {
        //        UserName = User.Identity.Name,
        //        Action = "Driver was deleted. Driver name " + driverToDelete.Name,
        //        DateTime = DateTime.Now
        //    };
        //    _context.UserActions.Add(userAction);
        //    _context.SaveChanges();

        //}
    }
}
