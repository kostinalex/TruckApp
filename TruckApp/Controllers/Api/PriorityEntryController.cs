using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TruckApp.Models;

namespace TruckApp.Controllers.Api
{
    public class PriorityEntryController : ApiController
    {
        private ApplicationDbContext _context;
        public PriorityEntryController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////


        public IEnumerable<PriorityEntry> GetpriorityEntry()
        {
            return _context.PriorityEntries.ToList();
        }


        public IHttpActionResult GetpriorityEntry(int id)
        {
            var priorityEntryToGet = _context.PriorityEntries.SingleOrDefault(c => c.Id == id);

            if (priorityEntryToGet == null)
                return NotFound();

            return Ok(priorityEntryToGet);
        }

        [HttpPost]
        public IHttpActionResult New(PriorityEntry priorityEntry)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.PriorityEntries.Add(priorityEntry);


            var userAction = new UserAction
            {
                UserName = User.Identity.Name,
                Action = "PriorityEntry was created. PriorityEntry name " + priorityEntry.Name,
                DateTime = DateTime.Now
            };
            _context.UserActions.Add(userAction);



            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + priorityEntry.Id), priorityEntry);
        }

        [HttpPut]
        public void EditpriorityEntry(int id, PriorityEntry priorityEntry)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var PriorityEntryToEdit = _context.PriorityEntries.SingleOrDefault(c => c.Id == id);

            PriorityEntryToEdit.Name = priorityEntry.Name;

            var userAction = new UserAction
            {
                UserName = User.Identity.Name,
                Action = "PriorityEntry was edited. PriorityEntry name " + priorityEntry.Name,
                DateTime = DateTime.Now
            };
            _context.UserActions.Add(userAction);


            _context.SaveChanges();

        }

        [HttpDelete]
        public void DeletepriorityEntry(int id)
        {
            var priorityEntryToDelete = _context.PriorityEntries.SingleOrDefault(c => c.Id == id);

            if (priorityEntryToDelete == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.PriorityEntries.Remove(priorityEntryToDelete);


            var userAction = new UserAction
            {
                UserName = User.Identity.Name,
                Action = "PriorityEntry was deleted. PriorityEntry name " + priorityEntryToDelete.Name,
                DateTime = DateTime.Now
            };
            _context.UserActions.Add(userAction);


            _context.SaveChanges();

        }
    }
}
