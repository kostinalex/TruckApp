using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckApp.ViewModels
{
    public class DriversReportViewModel
    {
        public int DriverId { get; set; }
        public string DriverName { get; set; }
        public int LegId { get; set; }
        public int LoadConfirmationId { get; set; }
        public decimal? Distance { get; set; }
        public TimeSpan? TimeSpent { get; set; }
        public decimal? DriverPay { get; set; }
    }
}