using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TruckApp.Models;

namespace TruckApp.Controllers
{
    [Authorize(Roles = RoleName.CanManageDispatchDriversAndOther)]
    public class DriversController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View("New");
        }
    }
}