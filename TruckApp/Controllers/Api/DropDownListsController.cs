using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TruckApp.Models;
using TruckApp.ViewModels;
using System.Data.Entity;
using System.Net.Mail;
using System.Threading.Tasks;
using System.IO;
using System.Web;
using System.Text;

namespace TruckApp.Controllers.Api
{
    [Authorize(Roles = RoleName.CanEnter)]
    public class DropDownListsController : ApiController
    {

        private ApplicationDbContext _context;
        public DropDownListsController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }



        [HttpGet]
        [Route("api/getdropdownlists")]
        public DropDownListsViewModel GetDropDownLists()
        {
            var result = new DropDownListsViewModel
            {
                Dispatches = _context.Dispatches.ToList(),
                Equipments = _context.Equipments.ToList(),
                HazMatStatuses = _context.HazMatStatuses.ToList(),
                PriorityDeliveries = _context.PriorityDeliveries.ToList(),
                PriorityEntries = _context.PriorityEntries.ToList()
            };

            return result; 
        }

        [HttpGet]
        [Route("api/getloadinfo/{id}")]
        public EditLoadViewForm GetLoadInfo(int id)
        {

            //var stopsToGet = _context.Stops.Where(c => c.LoadConfirmationId == id).ToList();
            //var loadConfirmationToGet = _context.LoadConfirmations
            //    .Include(c => c.Customer)
            //    .Include(m => m.HazMatStatus)
            //    .Include(a => a.Equipment)
            //    .Include(b => b.PriorityDelivery)
            //    .Include(d => d.PriorityEntry)
            //    .Include(e => e.Dispatch)
            //    .SingleOrDefault(c => c.Id == id);

            Console.WriteLine("");

            var dispatches = _context.Dispatches.ToList();

            Console.WriteLine("");

            var equipments = _context.Equipments.ToList();

            Console.WriteLine("");

            var hazMats = _context.HazMatStatuses.ToList();

            Console.WriteLine("");

            var deliveries = _context.PriorityDeliveries.ToList();

            Console.WriteLine("");

            var entries = _context.PriorityEntries.ToList();

            Console.WriteLine("");

            var stops = _context.Stops.Where(c => c.LoadConfirmationId == id).ToList();

            Console.WriteLine("");

            var load = _context.LoadConfirmations
                    .Include(c => c.Customer)
                    .Include(m => m.HazMatStatus)
                    .Include(a => a.Equipment)
                    .Include(b => b.PriorityDelivery)
                    .Include(d => d.PriorityEntry)
                    .Include(e => e.Dispatch)
                    .SingleOrDefault(c => c.Id == id);
            var notes=_context.Notes.Where(c => c.LoadConfirmationId == id).ToList();

            Console.WriteLine("");

            var result = new EditLoadViewForm
            {
                Dispatches = dispatches,
                Equipments = equipments,
                HazMatStatuses = hazMats,
                PriorityDeliveries = deliveries,
                PriorityEntries = entries,
                Stops= stops,
                LoadConfirmation= load,
                Notes= notes

            };


            return result;
        }

        //[HttpPost]
        //[AllowAnonymous]
        //[Route("api/emailwithattachment")]
        //public string EmailWithAttachment()
        //{
        //    try
        //    {

        //        MailMessage mail = new MailMessage();
        //        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com", 587);
        //        mail.From = new MailAddress("truckapp2607@gmail.com");
        //        mail.To.Add("kostin2607@gmail.com");
        //        mail.Subject = "Test Mail - 1";
        //        mail.Body = "mail with attachment";

        //        System.Net.Mail.Attachment attachment;
        //        attachment = new System.Net.Mail.Attachment("c:/test.txt");
        //        mail.Attachments.Add(attachment);


        //        SmtpServer.Credentials = new NetworkCredential("truckapp2607@gmail.com", "Kuka_7_Racha_1");
        //        SmtpServer.EnableSsl = true;

        //        SmtpServer.Send(mail);

        //    }
        //    catch (Exception e)
        //    {
        //        return "Error="+e;
        //    }
        //    return "Success";
        //}


        //[HttpPost]
        //public async Task<string> UploadFileViaModel(Message model)
        //{
        //    if (model == null || model.FileToUpload == null || model.FileToUpload.Length == 0)
        //        return "file not selected";

        //    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", model.FileToUpload.FileName);

        //    using (var stream = new FileStream(path, FileMode.Create))
        //    {
        //        await model.FileToUpload.CopyToAsync(stream);
        //    }

        //    return "Success";
        //}





        [HttpDelete]
        [AllowAnonymous]
        [Route("api/deletefile1")]
        public string DeleteFile()
        {
            try
            {
                File.Delete("c:\\users\\наталья\\documents\\visual studio 2017\\Projects\\TruckApp\\TruckApp\\UploadedFiles\\CONF  2020-04-26T20-20-51.pdf");
            }
            catch (Exception e)
            {
                return e.Message;
            }
            
            return "Success";
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/emailwithattachment")]
        public async Task<string> UploadFile()
        {

            var ctx = HttpContext.Current;
            var root = ctx.Server
                .MapPath("~/UploadedFiles");
            var provider =
                new MultipartFormDataStreamProvider(root);

            await Request.Content
                .ReadAsMultipartAsync(provider);

            var To = "";
            var Subject = "";
            var Body = "";

            foreach (var key in provider.FormData.AllKeys)
            {
                foreach (var val in provider.FormData.GetValues(key))
                {
                    if (key == "to")
                        To = val;
                    if (key == "subject")
                        Subject = val;
                    if (key == "body")
                        Body = val;
                }
            }

            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com", 587);
            mail.From = new MailAddress("truckapp2607@gmail.com");
            mail.To.Add(To);
            mail.Subject = Subject;
            mail.Body = Body;
            SmtpServer.Credentials = new NetworkCredential("truckapp2607@gmail.com", "Kuka_7_Racha_1");
            SmtpServer.EnableSsl = true;


            System.Net.Mail.Attachment attachment;

            List<string> filePaths = new List<string>();

            foreach (var file in provider.FileData)
            {
                var fileName = "CONF " + " " + DateTime.Now.ToString("yyyy-MM-ddTHH-mm-ss") + ".pdf";

                var localFileName = file.LocalFileName;
                var filePath = Path.Combine(root, fileName);
                File.Move(localFileName, filePath);

                attachment = new System.Net.Mail.Attachment(filePath);
                mail.Attachments.Add(attachment);
                filePaths.Add(filePath);


            }

            SmtpServer.Send(mail);

            mail.Dispose();/////Here was the problem

            foreach (var file in filePaths)
            {
                try
                {
                    Console.WriteLine(file);
                    File.Delete(file);
                }
                catch (Exception e)
                {

                    return e.Message;
                }
            }
            return "success";
        }

        //         [HttpPost]
        //[AllowAnonymous]
        //[Route("api/emailwithattachment")]
        //public async Task<string> UploadFile(Message message)
        //{
        //    var ctx = HttpContext.Current;
        //    var root = ctx.Server
        //        .MapPath("~/UploadedFiles");
        //    var provider =
        //        new MultipartFormDataStreamProvider(root);
        //    //try
        //    //{
        //    await Request.Content
        //        .ReadAsMultipartAsync(provider);

        //    MailMessage mail = new MailMessage();
        //    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com", 587);
        //    mail.From = new MailAddress("truckapp2607@gmail.com");
        //    mail.To.Add("kostin2607@gmail.com");
        //    mail.Subject = "lol";
        //    mail.Body = "mail with attachment";
        //    SmtpServer.Credentials = new NetworkCredential("truckapp2607@gmail.com", "Kuka_7_Racha_1");
        //    SmtpServer.EnableSsl = true;


        //    System.Net.Mail.Attachment attachment;

        //    List<string> filePaths = new List<string>();


        //    foreach (var file in provider.FileData)
        //    {
        //        var fileName = "CONF " + " " + DateTime.Now.ToString("yyyy-MM-ddTHH-mm-ss") + ".pdf";

        //        var localFileName = file.LocalFileName;
        //        var filePath = Path.Combine(root, fileName);
        //        File.Move(localFileName, filePath);

        //        attachment = new System.Net.Mail.Attachment(filePath);
        //        mail.Attachments.Add(attachment);
        //        filePaths.Add(filePath);

        //    }

        //    SmtpServer.Send(mail);

        //    foreach (var file in filePaths)
        //    {
        //        try
        //        {
        //            Console.WriteLine(file);
        //            File.SetAttributes(file, FileAttributes.Normal);
        //            File.Delete(file);
        //        }
        //        catch (Exception e)
        //        {
        //            StringBuilder sb = new StringBuilder();

        //            sb.Append("error=" + e.Message);

        //            File.AppendAllText(@"c:\test.txt", sb.ToString());
        //            sb.Clear();
        //            Console.WriteLine(e.Message);
        //            return e.Message;
        //        }

        //    }




            //}
            ////catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //    return $"Oops.Error:{e.Message}";
            ////}
            //return "Email with attachment has been sent";
        //}


        [HttpPost]
        [AllowAnonymous]
        [Route("api/email")]
        public async Task<string> Email()
        {
            try
            {
                var client = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential("truckapp2607@gmail.com", "Kuka_7_Racha_1"),
                    EnableSsl = true
                };
                await client.SendMailAsync("truckapp2607@gmail.com", "kostin2607@gmail.com", "Someone entered the website as a visitor", "Now=" + DateTime.Now);



            }
            catch (Exception e)
            {
                return "Error=" + e;
            }
            return "Success";
        }
       
    }
}
