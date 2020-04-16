using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TruckApp.Models;

namespace TruckApp.Controllers
{
    [Authorize(Roles = RoleName.CanSeeReports)]
    public class DriversReportController : Controller
    {
        // GET: DrivesReport
        public ActionResult Index()
        {
            return View();
        }
    }
}