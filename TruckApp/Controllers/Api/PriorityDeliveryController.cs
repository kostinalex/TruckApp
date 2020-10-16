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
    public class PriorityDeliveryController : ApiController
    {
        private ApplicationDbContext _context;
        public PriorityDeliveryController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////


        public IEnumerable<PriorityDelivery> GetpriorityDelivery()
        {
            return _context.PriorityDeliveries.ToList();
        }


        public IHttpActionResult GetpriorityDelivery(int id)
        {
            var priorityDeliveryToGet = _context.PriorityDeliveries.SingleOrDefault(c => c.Id == id);

            if (priorityDeliveryToGet == null)
                return NotFound();

            return Ok(priorityDeliveryToGet);
        }

        [HttpPost]
        [Authorize(Roles = RoleName.CanManageDispatchDriversAndOther)]
        public IHttpActionResult New(PriorityDelivery priorityDelivery)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.PriorityDeliveries.Add(priorityDelivery);


            var userAction = new UserAction
            {
                UserName = User.Identity.Name,
                Action = "PriorityDelivery was created. PriorityDelivery name " + priorityDelivery.Name,
                DateTime = DateTime.Now
            };
            _context.UserActions.Add(userAction);



            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + priorityDelivery.Id), priorityDelivery);
        }

        [HttpPut]
        [Authorize(Roles = RoleName.CanManageDispatchDriversAndOther)]
        public void EditpriorityDelivery(int id, PriorityDelivery priorityDelivery)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var PriorityDeliveryToEdit = _context.PriorityDeliveries.SingleOrDefault(c => c.Id == id);

            PriorityDeliveryToEdit.Name = priorityDelivery.Name;

            var userAction = new UserAction
            {
                UserName = User.Identity.Name,
                Action = "PriorityDelivery was edited. PriorityDelivery name " + priorityDelivery.Name,
                DateTime = DateTime.Now
            };
            _context.UserActions.Add(userAction);


            _context.SaveChanges();

        }

        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageDispatchDriversAndOther)]
        public void DeletepriorityDelivery(int id)
        {
            var priorityDeliveryToDelete = _context.PriorityDeliveries.SingleOrDefault(c => c.Id == id);

            if (priorityDeliveryToDelete == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.PriorityDeliveries.Remove(priorityDeliveryToDelete);

            var userAction = new UserAction
            {
                UserName = User.Identity.Name,
                Action = "PriorityDelivery was deleted. PriorityDelivery name " + priorityDeliveryToDelete.Name,
                DateTime = DateTime.Now
            };
            _context.UserActions.Add(userAction);

            _context.SaveChanges();

        }
    }
}
