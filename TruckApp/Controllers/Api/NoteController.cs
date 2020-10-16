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
    public class NoteController : ApiController
    {
        private ApplicationDbContext _context;
        public NoteController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////


        public IHttpActionResult GetNote(int id)
        {
            var noteToGet = _context.Notes.SingleOrDefault(c => c.Id == id);

            if (noteToGet == null)
                return NotFound();

            return Ok(noteToGet);
        }

        [HttpPut]
        [Authorize(Roles = RoleName.CanManageNotes)]
        public void EditNote(int id, Note note)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var noteToEdit = _context.Notes.SingleOrDefault(c => c.Id == id);
            if(noteToEdit==null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            noteToEdit.NoteContent = note.NoteContent;
            noteToEdit.DateAdded = note.DateAdded;
            noteToEdit.Header = note.Header;

            var userAction = new UserAction
            {
                UserName = User.Identity.Name,
                Action = "Note was edited. Note content "+ note.Header + note.NoteContent,
                DateTime = DateTime.Now
            };
            _context.UserActions.Add(userAction);

            _context.SaveChanges();

        }

        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageNotes)]
        public void DeleteNote(int id)
        {
            var noteToDelete = _context.Notes.SingleOrDefault(c => c.Id == id);

            if (noteToDelete == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Notes.Remove(noteToDelete);


            var userAction = new UserAction
            {
                UserName = User.Identity.Name,
                Action = "Note was deleted. Note content " + noteToDelete.Header + noteToDelete.NoteContent,
                DateTime = DateTime.Now
            };
            _context.UserActions.Add(userAction);


            _context.SaveChanges();

        }

    }
}
