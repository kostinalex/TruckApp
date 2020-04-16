using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckApp.Models;

namespace TruckApp.ViewModels
{
    public class LoadFormViewModel
    {
        public LoadConfirmation LoadConfirmation { get; set; }
        public Customer Customer { get; set; }

        public IEnumerable<HazMatStatus> HazmatStatuses { get; set; }
        public IEnumerable<Equipment> Equipments { get; set; }

        public IEnumerable<PriorityDelivery> PriorityDeliveries { get; set; }
        public IEnumerable<PriorityEntry> PriorityEntries { get; set; }
        public IEnumerable<Dispatch> Dispatches { get; set; }
        public IEnumerable<Driver> Drivers { get; set; }



    }
}