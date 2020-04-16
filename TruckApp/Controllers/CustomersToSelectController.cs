using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TruckApp.Models;

namespace TruckApp.Controllers
{
    [Authorize(Roles = RoleName.CanEnter)]
    public class CustomersToSelectController : Controller
    {
        // GET: CustomersToSelect
        public ActionResult Index()
        {
            return View();
        }
    }
}