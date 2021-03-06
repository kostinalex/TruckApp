﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckApp.ViewModels
{
    public class InputLoadReportViewModel
    {
        public string UserName { get; set; }
        public int CustomerId { get; set; }
        //public string CustomerName { get; set; }
        public decimal Rate1 { get; set; }
        public decimal Rate2 { get; set; }
        public int DispatchId { get; set; }
        //public string DispatchName { get; set; }
        public bool? CreditHold { get; set; }
        public bool? POD { get; set; }
        public bool? Void { get; set; }
        public bool? Closed { get; set; }
        public bool? Exported { get; set; }
    }
}