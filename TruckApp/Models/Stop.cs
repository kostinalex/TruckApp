using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckApp.Models
{
    public class Stop
    {
        public int Id { get; set; }
        public int LoadConfirmationId { get; set; }
        public LoadConfirmation LoadConfirmation { get; set; }
        public byte OrderNumber { get; set; }
        public bool PUStatus { get; set; }
        public bool DelStatus { get; set; }
        public string FacilityName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }

        public DateTime Date1 { get; set; }
        public DateTime Date2 { get; set; }


        //public DateTime DelDate1 { get; set; }
        //public DateTime DelDate2 { get; set; }
        //public DateTime DelTime1 { get; set; }
        //public DateTime DelTime2 { get; set; }
    }
}