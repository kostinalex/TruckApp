using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TruckApp.Models;
using System.Data.Entity;
using TruckApp.ViewModels;

namespace TruckApp.Controllers.Api
{
    [Authorize(Roles = RoleName.CanEnter)]
    public class LegsController : ApiController
    {
        private ApplicationDbContext _context;
        public LegsController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////


        //

        [HttpGet]
        [Route("api/legs/{id}")]
        public IHttpActionResult GetLegs(int id)
        {
            //var id = 85;
            var legsToGet = _context.Legs
                .Include(c => c.Stop1)
                .Include(c => c.Stop2)
                .Include(c => c.Driver)
                .Where(c => c.LoadConfirmationId == id).ToList();



            return Ok(legsToGet);
        }

        [HttpPost]
        public IHttpActionResult New(Leg leg)
        {

            _context.Legs.Add(leg);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + leg.Id), leg);
        }

        [HttpPut]
        public void EditLegs(LegsTableViewModel leg)
        {
            //if (!ModelState.IsValid)
            //    throw new HttpResponseException(HttpStatusCode.BadRequest);

            var legToEdit = _context.Legs.Single(c => c.Id == leg.Id);
            var driverToAttach = _context.Drivers.Single(c => c.Id == leg.DriverId);


                legToEdit.DriverId = driverToAttach.Id;
                legToEdit.Driver = driverToAttach;

                legToEdit.DateTime1 = leg.DateTime1;
                legToEdit.DateTime2 = leg.DateTime2;
            legToEdit.Distance = leg.Distance;
            legToEdit.DriverPay = leg.DriverPay;

            _context.SaveChanges();
        }

        [HttpDelete]
        [Route("api/legs/{id}")]
        public void DeleteLeg(int id)
        {
            ///DELETE ALL OLD LEGS WITH CONF ID == ID
            var legToDelete = _context.Legs.Where(c => c.LoadConfirmationId == id);

            if (legToDelete == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            foreach (var leg in legToDelete)
            {
                _context.Legs.Remove(leg);
            }                       
            _context.SaveChanges();
        }

        [HttpDelete]
        [Route("api/UpdateLegs/{id}")]
        public void UpdateLegs(int id)
        {            
            /// CREATE NEW LEGS
            var allStopsForLoad = _context.Stops.Where(c => c.LoadConfirmationId == id);

            var delOrderNumber = allStopsForLoad.Single(c => c.DelStatus == true).OrderNumber;

            var previousStop = new Stop { };

            for (int i = 1; i <= delOrderNumber; i++)
            {
                var currentStop = allStopsForLoad.Single(c => c.OrderNumber == i);

                if (i != 1)
                {
                    var leg = new Leg
                    {
                        LoadConfirmationId = id,
                        //DriverId = 8,
                        Stop1Id = previousStop.Id,
                        Stop2Id = currentStop.Id
                    };
                    _context.Legs.Add(leg);

                }
                previousStop = currentStop;
            }
            _context.SaveChanges();

        }
    }
}
