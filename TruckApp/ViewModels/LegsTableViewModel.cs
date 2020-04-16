using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckApp.Models;

namespace TruckApp.ViewModels
{
    public class LegsTableViewModel
    {
        public int Id { get; set; }
        public int DriverId { get; set; }
        public DateTime? DateTime1 { get; set; }
        public DateTime? DateTime2 { get; set; }
        public decimal Distance { get; set; }
        public decimal DriverPay { get; set; }


    }
}