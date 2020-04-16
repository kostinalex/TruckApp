using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using TruckApp.Models;

namespace TruckApp.Controllers
{
    [Authorize(Roles = RoleName.CanEnter)]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase files)
        {
            // Verify that the user selected a file
            if (files != null && files.ContentLength > 0)
            {
                // extract only the filename
                var fileName = Path.GetFileName(files.FileName);
                // store the file inside ~/App_Data/uploads folder
                var path = Path.Combine(Server.MapPath("~/Uploaded files"), fileName);
                files.SaveAs(path);
            }
            // redirect back to the index action to show the form once again
            return RedirectToAction("Index");
        }
    }
}