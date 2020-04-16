using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace TruckApp.Models
{
    public static class UserExtensions
    {
        public static ApplicationUser ApplicationUser(this IPrincipal principal)
        {
            return (ApplicationUser)principal.Identity;
        }
    }
}