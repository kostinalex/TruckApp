using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TruckApp.Models;
using TruckApp.ViewModels;


namespace TruckApp.Controllers.Api
{
    
    public class UserActionsController : ApiController
    {
        private ApplicationDbContext _context;
        public UserActionsController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// 



        [HttpGet]
        [Route("api/GetAllUsersActions")]
        [Authorize(Roles = RoleName.CanSeeAllUserActions)]
        public IEnumerable<UserAction> GetAllUsersActions()
        {
            return _context.UserActions.ToList();
        }

        [HttpGet]
        [Route("api/GetUsersActionsForLoad/{id}")]
        [Authorize(Roles = RoleName.CanSeeUsersActionsWithLoad)]
        public IEnumerable<UserAction> GetUserActionsForLoad(int id)
        {
            return _context.UserActions.Where(c=>c.LoadConfirmationId==id).ToList();
        }


        [HttpPost]
        [Route("api/GetAllActionsWithCondition")]
        [Authorize(Roles = RoleName.CanSeeAllUserActions)]
        public IEnumerable<UserAction> GetAllActionsWithCondition(UserActionsViewModel userActions)
        {

            if (userActions == null)
            {
                return _context.UserActions.ToList();
            }


            var timeSpan = new TimeSpan(23,59,0);
            userActions.DateTime2 = userActions.DateTime2 + timeSpan;
            var dateTimeForComparison = new DateTime(0002,01,01);

            if (userActions.DateTime2 < dateTimeForComparison)
                userActions.DateTime2 = DateTime.Now;


            if (userActions.UserName != null)
            {
                return _context.UserActions
                    .Where(t => t.DateTime >= userActions.DateTime1)
                    .Where(t => t.DateTime <= userActions.DateTime2)
                    .Where(c => c.UserName == userActions.UserName).ToList();
            }
            else
            {
                return _context.UserActions
                    .Where(t => t.DateTime >= userActions.DateTime1)
                    .Where(t => t.DateTime <= userActions.DateTime2)
                    .ToList();
            }

        }

    }
}
