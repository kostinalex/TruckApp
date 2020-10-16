using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TruckApp.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using System.Web;
using TruckApp.ViewModels;
using TruckApp.Controllers;
using Microsoft.AspNet.Identity.Owin;



namespace TruckApp.Controllers.Api
{
    
    public class UsersController : ApiController
    {
        //         

        private ApplicationDbContext _context;
        public UsersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        private ApplicationUserManager _userManager; 

        public UsersController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            
        }
        public ApplicationUserManager UserManager
        {
            get
            {
               return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }


        /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// 


        //////////////////FOR USERS INDEX LIST
        [Authorize(Roles = "CanSeeAllUserActions,CanManageUsers")]
       
        public IEnumerable<ApplicationUser> GetUsers()
        {
            return _context.Users.ToList();
        }


        //////////////////GET ALL ROLES ASSIGNED TO ONE USER
        [HttpPost]
        [Route("api/getuser")]
        [Authorize(Roles = RoleName.CanManageUsers)]
        public List<string> GetUser(RoleViewModel roleViewModel)
        {
            var userToGet= _context.Users.SingleOrDefault(c => c.Id == roleViewModel.UserId);

            List<string> rolesOfGetUser = new List<string>();

            foreach (var role in userToGet.Roles)
            {
                var roleName = _context.Roles.Single(c => c.Id == role.RoleId);
                rolesOfGetUser.Add(roleName.Name);
            }


            //var viewModel = new GetUsersAndRolesViewModel
            //{
            //    UserId = userToGet.Id,
            //    UserName = userToGet.UserName,
            //    UserRoles = rolesOfGetUser
            //};

            return rolesOfGetUser;
        }

        [HttpPost]
        [Route("api/getusername")]
        [Authorize(Roles = RoleName.CanManageUsers)]
        public string GetUserName(RoleViewModel roleViewModel)
        {
            var userToGet = _context.Users.SingleOrDefault(c => c.Id == roleViewModel.UserId);

            return userToGet.UserName;
        }


        ///////////////NEW ONE ROLE FOR ONE USER
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageUsers)]
        public async Task New(RoleViewModel roleViewModel)
        {
            var userAction = new UserAction
            {
                UserName = User.Identity.Name,
                Action = "New role was assigned. User name " + 
                _context.Users.SingleOrDefault(c => c.Id == roleViewModel.UserId).UserName 
                + " User role " + roleViewModel.UserRole,
                DateTime = DateTime.Now
            };
            _context.UserActions.Add(userAction);
            _context.SaveChanges();

            await UserManager.AddToRoleAsync(roleViewModel.UserId, roleViewModel.UserRole);
        }

        ////////////////////DELETE ONE ROLE

        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageUsers)]
        public async Task DeleteUserRoles(RoleViewModel roleViewModel)
        {

            var userAction = new UserAction
            {
                UserName = User.Identity.Name,
                Action = "Role was deleted. User name " 
                + _context.Users.SingleOrDefault(c=>c.Id==roleViewModel.UserId).UserName 
                + " User role " + roleViewModel.UserRole,
                DateTime = DateTime.Now
            };
            _context.UserActions.Add(userAction);
            _context.SaveChanges();

            await UserManager.RemoveFromRoleAsync(roleViewModel.UserId, roleViewModel.UserRole);
        }

        ////////////////////GET LIST OF  ALL ROLES FOR DROPDOWN
        [Route("api/roles")]
        [Authorize(Roles = RoleName.CanManageUsers)]
        public IEnumerable<IdentityRole> GetRoles()//Table in the middle
        {
            return _context.Roles.ToList();
        }

        ///////////////DARK THEME ASSIGN//////////////////
        [HttpPost]
        [Route("api/darktheme")]
        [Authorize(Roles = RoleName.CanEnter)]
        public async Task DarkThemeApply(RoleViewModel roleViewModel)
        {

            var userId = _context.Users.SingleOrDefault(c => c.UserName == roleViewModel.UserName).Id;

            await UserManager.AddToRoleAsync(userId, RoleName.DarkTheme);
            
            
        }


        ////////////////////DARK THEME DISABLE///////////////////

        [HttpDelete]
        [Route("api/darktheme")]
        [Authorize(Roles = RoleName.CanEnter)]
        public async Task DarkThemeDisable(RoleViewModel roleViewModel)
        {

            var userId = _context.Users.SingleOrDefault(c => c.UserName == roleViewModel.UserName).Id;

            await UserManager.RemoveFromRoleAsync(userId, RoleName.DarkTheme);
        }



        ////////////////////DARK THEME DISABLE///////////////////

        [HttpPost]
        [Route("api/getdarktheme")]
        [Authorize(Roles = RoleName.CanEnter)]
        public bool DarkThemeStatus(RoleViewModel roleViewModel)
        {


            var userToGet = _context.Users.SingleOrDefault(c => c.UserName == roleViewModel.UserName);

            var roleId=_context.Roles.SingleOrDefault(c => c.Name == RoleName.DarkTheme).Id;


            var darkThemeStatus = (userToGet.Roles.SingleOrDefault(c => c.RoleId == roleId)==null?false:true);
                       

            return darkThemeStatus;
        }

    }
}
