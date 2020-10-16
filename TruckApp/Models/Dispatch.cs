using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckApp.Models
{
    public class Dispatch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool? Void { get; set; }
    }
}