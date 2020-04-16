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
using Microsoft.Owin.Security;
using System.Runtime.Remoting.Contexts;

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
        public IEnumerable<ApplicationUser> GetUsers()
        {
            return _context.Users.ToList();
        }


        //////////////////GET ALL ROLES ASSIGNED TO ONE USER
        [HttpPost]
        [Route("api/getuser")]
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
        public string GetUserName(RoleViewModel roleViewModel)
        {
            var userToGet = _context.Users.SingleOrDefault(c => c.Id == roleViewModel.UserId);

            return userToGet.UserName;
        }


        ///////////////NEW ONE ROLE FOR ONE USER
        [HttpPost]
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
        public IEnumerable<IdentityRole> GetRoles()//Table in the middle
        {
            return _context.Roles.ToList();
        }









        ///////////////DARK THEME ASSIGN//////////////////
        [HttpPost]
        [Route("api/darktheme")]
        public async Task DarkThemeApply(RoleViewModel roleViewModel)
        {

            var userId = _context.Users.SingleOrDefault(c => c.UserName == roleViewModel.UserName).Id;

            await UserManager.AddToRoleAsync(userId, RoleName.DarkTheme);
            
            
        }


        ////////////////////DARK THEME DISABLE///////////////////

        [HttpDelete]
        [Route("api/darktheme")]
        public async Task DarkThemeDisable(RoleViewModel roleViewModel)
        {

            var userId = _context.Users.SingleOrDefault(c => c.UserName == roleViewModel.UserName).Id;

            await UserManager.RemoveFromRoleAsync(userId, RoleName.DarkTheme);
        }



        ////////////////////DARK THEME DISABLE///////////////////

        [HttpPost]
        [Route("api/getdarktheme")]
        public bool DarkThemeStatus(RoleViewModel roleViewModel)
        {


            var userToGet = _context.Users.SingleOrDefault(c => c.UserName == roleViewModel.UserName);

            var roleId=_context.Roles.SingleOrDefault(c => c.Name == RoleName.DarkTheme).Id;


            var darkThemeStatus = (userToGet.Roles.SingleOrDefault(c => c.RoleId == roleId)==null?false:true);
                       

            return darkThemeStatus;
        }








        //[HttpDelete]
        //public async Task DeleteUserRoles(RoleViewModel roleViewModel)
        //{            
        //    await UserManager.RemoveFromRolesAsync(roleViewModel.UserId, UserManager.GetRoles(roleViewModel.UserId).ToArray());
        //}
        //[HttpPost]
        //public async Task New()
        //{

        //    var userId = "ec6ea171-70f5-4fd9-93f2-5a05a2f88e3b";
        //    var role = "CanDeleteCustomer";

        //    await UserManager.AddToRoleAsync(userId, role);

        //}


        //{

        //"userId":"ec6ea171-70f5-4fd9-93f2-5a05a2f88e3b",
        //"userRole":"HasAccessToLegs"

        //}



        //[HttpPut]
        //public void EditUserRole(ApplicationUser user)
        //{
        //    if (!ModelState.IsValid)
        //        throw new HttpResponseException(HttpStatusCode.BadRequest);

        //    var userToEdit = _context.Users.SingleOrDefault(c => c.Id == user.Id);

        //    userToEdit.Roles = user.Roles;

        //    _context.SaveChanges();

        //}





        //            var user = await UserManager.FindByIdAsync(userId);
        //IdentityResult deletionResult = await UserManager.RemoveFromRoleAsync("ec6ea171-70f5-4fd9-93f2-5a05a2f88e3b", "CanDeleteCustomer");

        //await UserManager.AddToRoleAsync(userId, "NewRole");
        //await UserManager.UpdateAsync(user);














        //public IdentityRole GetRole()//Table in the middle
        //{
        //    return _context.Roles.Single(c=>c.Name== "CanDeleteCustomer");
        //}





        //public IEnumerable<AspNetUser> GetRoles()//Table in the middle
        //{
        //    return _context.Roles.Include(c => c.Users).ToList();
        //}


        //var roles = await UserManager.GetRolesAsync(userid);
        //await UserManager.RemoveFromRolesAsync(userid, roles.ToArray());

        //var roleStore = new RoleStore<IdentityRole>(new ApplicationDbContext());
        //var roleManager = new RoleManager<IdentityRole>(roleStore);
        //await roleManager.CreateAsync(new IdentityRole("CanManageNotes"));
        //await UserManager.AddToRoleAsync(user.Id, "CanManageNotes");

        //if (User.IsInRole(RoleModels.CanManageCustomers))
        //            {
        //                var usersList1 = _context.Users.ToList();
        //                return View("Index", usersList1);
        //    }
        //            else
        //            {
        //                return View("ReadOnlyList");
        //}



    }
}
