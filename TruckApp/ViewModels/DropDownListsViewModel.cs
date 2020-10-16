using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckApp.Models;

namespace TruckApp.ViewModels
{
    public class DropDownListsViewModel
    {
        public List<Dispatch> Dispatches { get; set; }
        public List<PriorityDelivery> PriorityDeliveries { get; set; }
        public List<HazMatStatus> HazMatStatuses { get; set; }
        public List<PriorityEntry> PriorityEntries { get; set; }
        public List<Equipment> Equipments { get; set; }

    }
}