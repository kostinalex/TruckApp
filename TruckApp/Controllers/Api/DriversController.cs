using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TruckApp.Models;

namespace TruckApp.Controllers.Api
{
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





        public IEnumerable<Driver> GetDrivers(string query = null)
        {
            if (!string.IsNullOrEmpty(query))
            {
                var driversQuery = _context.Drivers.Where(c => c.Name.Contains(query));
                return driversQuery;
            }

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
        public void EditDriver(int id, Driver driver)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var DriverToEdit = _context.Drivers.SingleOrDefault(c => c.Id == id);

            DriverToEdit.Name = driver.Name;

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
        public void DeleteDriver(int id)
        {
            var driverToDelete = _context.Drivers.SingleOrDefault(c => c.Id == id);

            if (driverToDelete == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);



            _context.Drivers.Remove(driverToDelete);

            var userAction = new UserAction
            {
                UserName = User.Identity.Name,
                Action = "Driver was deleted. Driver name " + driverToDelete.Name,
                DateTime = DateTime.Now
            };
            _context.UserActions.Add(userAction);
            _context.SaveChanges();

        }
    }
}
