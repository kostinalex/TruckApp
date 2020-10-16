using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.Threading.Tasks;
using System.IO;
using TruckApp.Models;
using TruckApp.ViewModels;
using System.Data.Entity;

namespace TruckApp.Controllers.Api
{
    [Authorize(Roles = RoleName.CanEnter)]
    public class FileUploadController : ApiController
    {
        private ApplicationDbContext _context;
        public FileUploadController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpPost]
        public async Task<string> UploadFile(int id)
        {
            var ctx = HttpContext.Current;
            var root = ctx.Server
                .MapPath("~/UploadedFiles");
            var provider =
                new MultipartFormDataStreamProvider(root);
            try
            {
                await Request.Content
                    .ReadAsMultipartAsync(provider);

                foreach (var file in provider.FileData)
                {
                    var fileName = "CONF " + id +" " + DateTime.Now.ToString("yyyy-MM-ddTHH-mm-ss") + ".pdf";

                    var localFileName = file
                        .LocalFileName;
                    var filePath = Path.Combine(root, fileName);
                    File.Move(localFileName, filePath);
                    var NewAttachment = new Attachment
                    {
                        Name= fileName,
                        Path= "/UploadedFiles/" + fileName,
                        LoadConfirmationId=id
                    };
                    var userAction = new UserAction
                    {
                        UserName = User.Identity.Name,
                        Action = "Attachment was added. Attachment name " + fileName,
                        DateTime = DateTime.Now
                    };
                    _context.UserActions.Add(userAction);

                    _context.Attachments.Add(NewAttachment);
                }




                _context.SaveChanges();
            }
            catch (Exception e)
            {
                return $"Oops.Error:{e.Message}";
            }
            return "File uploaded";
        }
    }
}
