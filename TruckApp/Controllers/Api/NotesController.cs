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
    public class NotesController : ApiController
    {
        private ApplicationDbContext _context;
        public NotesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////


        public IEnumerable<Note> GetNotes(int id)
        {
            var notesToGet = _context.Notes.Where(c => c.LoadConfirmationId == id).ToList();
            //if (notesToGet == null||notesToGet.Count==0)
            //    throw new HttpResponseException(HttpStatusCode.NotFound);

            //foreach(var note in notesToGet)
            //{
            //    note.DateAdded
            //}

            return notesToGet;
        }



        [HttpPost]
        public IHttpActionResult New(Note noteToCreate)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.Notes.Add(noteToCreate);


            var userAction = new UserAction
            {
                UserName = User.Identity.Name,
                Action = "Note was created. Note content " + noteToCreate.Header + noteToCreate.NoteContent,
                DateTime = DateTime.Now
            };
            _context.UserActions.Add(userAction);



            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + noteToCreate.Id), noteToCreate);
        }

        
    }
}
