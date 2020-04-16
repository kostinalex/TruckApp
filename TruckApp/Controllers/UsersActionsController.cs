using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TruckApp.Models;

namespace TruckApp.Controllers
{
    public class UsersActionsController : Controller
    {
        // GET: UsersActions
        [Authorize(Roles = RoleName.CanSeeAllUserActions)]
        public ActionResult Index()
        {
            return View();
        }
    }
}