using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckApp.Models
{
    public class UserAction
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Action { get; set; }
        public DateTime DateTime { get; set; }
        public int? LoadConfirmationId { get; set; }
        public LoadConfirmation LoadConfirmation { get; set; }
    }
}