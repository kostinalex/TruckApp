using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckApp.Models
{
    public class Leg
    {
        public int Id { get; set; }
        public int Stop1Id { get; set; }
        public Stop Stop1 { get; set; }
        public int Stop2Id { get; set; }
        public Stop Stop2 { get; set; }
        public int DriverId { get; set; }
        public Driver Driver { get; set; }
        public int LoadConfirmationId { get; set; }
        public LoadConfirmation LoadConfirmation { get; set; }
        public DateTime? DateTime1 { get; set; }
        public DateTime? DateTime2 { get; set; }
        public decimal? Distance { get; set; }
        public decimal? DriverPay { get; set; }
    }
}