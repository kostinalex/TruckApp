using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TruckApp.ViewModels
{
    public class GetUsersAndRolesViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        //public ICollection<IdentityUserRole> UserRoles { get; set; }
        public List<string> UserRoles { get; set; }
    }
}