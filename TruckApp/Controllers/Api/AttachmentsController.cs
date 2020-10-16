using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TruckApp.Models;
using TruckApp.ViewModels;
using System.Data.Entity;
using System.IO;
using System.Web;

namespace TruckApp.Controllers.Api
{
    [Authorize(Roles = RoleName.CanEnter)]
    public class AttachmentsController : ApiController
    {
        private ApplicationDbContext _context;
        public AttachmentsController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////


        public IEnumerable<Attachment> GetAttachments(int id)
        {
            return _context.Attachments.Where(c=>c.LoadConfirmationId==id).ToList();
        }


        [HttpDelete]
        public void DeleteAttachment(int id)
        {
            var attachmentToDelete = _context.Attachments.SingleOrDefault(c => c.Id == id);

            if (attachmentToDelete == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var filePath = HttpContext.Current.Server.MapPath("/UploadedFiles") 
                + "\\" + attachmentToDelete.Name;

            if (File.Exists(filePath))
            {


                File.Delete(filePath);
                _context.Attachments.Remove(attachmentToDelete);

                var userAction = new UserAction
                {
                    UserName = User.Identity.Name,
                    Action = "Attachment was deleted. Attachment path " + attachmentToDelete.Name,
                    DateTime = DateTime.Now
                };
                _context.UserActions.Add(userAction);

                _context.SaveChanges();
            }
            
        }
    }
}
