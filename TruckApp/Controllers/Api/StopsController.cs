using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TruckApp.Models;
using TruckApp.ViewModels;
using System.Data.Entity;

namespace TruckApp.Controllers.Api
{
    [Authorize(Roles = RoleName.CanEnter)]
    public class StopsController : ApiController
    {
        private ApplicationDbContext _context;
        public StopsController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////


        //public IEnumerable<Stop> GetStops()
        //{
        //    return _context.Stops.ToList();
        //}


        public IHttpActionResult GetStops(int id)
        {
            var stopsToGet = _context.Stops.Where(c => c.LoadConfirmationId == id).ToList();
            return Ok(stopsToGet);
        }

        [HttpPost]
        public IHttpActionResult New(Stop stop)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (stop.PUStatus!=true && stop.DelStatus != true)
            {
                var delStop = _context.Stops
                    .Where(c => c.DelStatus == true)
                    .Single(m => m.LoadConfirmationId == stop.LoadConfirmationId);
              
                if (delStop!=null)
                {
                    stop.OrderNumber = delStop.OrderNumber;
                    delStop.OrderNumber++;
                }             

            };

            var userAction = new UserAction
            {
                UserName = User.Identity.Name,
                Action = "New stop was added. Stop address " + stop.Address,
                DateTime = DateTime.Now
            };
            _context.UserActions.Add(userAction);

            _context.Stops.Add(stop);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + stop.Id), stop);
        }


        [HttpPut]
        public void EditStop(int id, Stop stop)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var stopToEdit = _context.Stops
                .Single(c => c.Id == id);

            if (stopToEdit.PUStatus == true || stopToEdit.DelStatus == true)
            {
                stopToEdit.FacilityName = stop.FacilityName;
                stopToEdit.Address = stop.Address;
                stopToEdit.City = stop.City;
                stopToEdit.State = stop.State;
                stopToEdit.Country = stop.Country;
                stopToEdit.ZipCode = stop.ZipCode;
                stopToEdit.Date1 = stop.Date1;
                stopToEdit.Date2 = stop.Date2;

                var userAction = new UserAction
                {
                    UserName = User.Identity.Name,
                    Action = "Stop was edited. Stop address " + stop.Address,
                    DateTime = DateTime.Now
                };
                _context.UserActions.Add(userAction);

                _context.SaveChanges();

            }



        }

        [HttpDelete]
        public void DeleteStop(int id)
        {
            var stopToDelete = _context.Stops.SingleOrDefault(c => c.Id == id);

            if (stopToDelete == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var stopsToFixOrder=_context.Stops
                .Where(m => m.LoadConfirmationId == stopToDelete.LoadConfirmationId);

            foreach(var stop in stopsToFixOrder)
            {
                if (stop.PUStatus != true && stop.OrderNumber > stopToDelete.OrderNumber)
                {
                    stop.OrderNumber--;
                }
                    
            }



            _context.Stops.Remove(stopToDelete);


            var userAction = new UserAction
            {
                UserName = User.Identity.Name,
                Action = "Stop was deleted. Stop address " + stopToDelete.Address,
                DateTime = DateTime.Now
            };
            _context.UserActions.Add(userAction);

            _context.SaveChanges();

        }
    }
}
