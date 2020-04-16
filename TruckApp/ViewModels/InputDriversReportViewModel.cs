using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckApp.ViewModels
{
    public class InputDriversReportViewModel
    {
        public int? DriverId { get; set; }
        public string DriverName { get; set; }
        public int LegId { get; set; }
        public int LoadConfirmationId { get; set; }
        public decimal? Distance1 { get; set; }
        public decimal? Distance2 { get; set; }
        public TimeSpan? TimeSpent1 { get; set; }
        public TimeSpan? TimeSpent2 { get; set; }
        public decimal? DriverPay1 { get; set; }
        public decimal? DriverPay2 { get; set; }
    }
}