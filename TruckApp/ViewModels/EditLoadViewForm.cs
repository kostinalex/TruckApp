using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckApp.Models;

namespace TruckApp.ViewModels
{
    public class EditLoadViewForm
    {
        public List<Dispatch> Dispatches { get; set; }
        public List<PriorityDelivery> PriorityDeliveries { get; set; }
        public List<HazMatStatus> HazMatStatuses { get; set; }
        public List<PriorityEntry> PriorityEntries { get; set; }
        public List<Equipment> Equipments { get; set; }
        public List<Stop> Stops { get; set; }
        public LoadConfirmation LoadConfirmation { get; set; }
        public List<Note> Notes { get; set; }
    }
}