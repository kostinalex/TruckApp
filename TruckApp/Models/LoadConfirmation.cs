using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TruckApp.Models
{
    public class LoadConfirmation
    {
        public int Id { get; set; }

        //[(ErrorMessage = "Please enter Customer Id.")]
        [Display(Name = "Customer Id")]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }       

        //[]
        //[Display(Name = "Freight Description")]
        public string FreightDescription { get; set; }
        //[]
        //[Display(Name = "Weight")]
        public int Weight { get; set; }
        //[]
        //[Display(Name = "Pallets")]
        public byte NumberOfPallets { get; set; }  

        public decimal Rate { get; set; }

        public int HazMatStatusId { get; set; }
        public HazMatStatus HazMatStatus { get; set; }

        public int EquipmentId { get; set; }
        public Equipment Equipment { get; set; }


        public int PriorityDeliveryId { get; set; }
        public PriorityDelivery PriorityDelivery { get; set; }

        public int PriorityEntryId { get; set; }
        public PriorityEntry PriorityEntry { get; set; }

        public int? DispatchId { get; set; }
        public Dispatch Dispatch { get; set; }

        //public int DriverId { get; set; }
        //public Driver Driver { get; set; }

        public bool CreditHold { get; set; }
        public bool POD { get; set; }
        public string ConfNumber { get; set; }
        public string CustomsBroker { get; set; }
        public int? HazMatNumber { get; set; }
        public bool Void { get; set; }
        public bool Closed { get; set; } = false;
        public bool Exported { get; set; } = false;



        //[(ErrorMessage = "Please enter Pick Up Address.")]
        //[Display(Name = "Pick Up Address")]
        //public string PickUpAddress { get; set; }

        //[(ErrorMessage = "Please enter Delivery Address.")]
        //[Display(Name = "Delivery Address")]
        //public string DeliveryAddress { get; set; }




        //[]
        //[Display(Name = "Pick Up Facility Name")]
        //public string PickUpFacilityName { get; set; }
        ////[]
        ////[Display(Name = "Pick Up Address")]
        //public string PickUpAddress { get; set; }
        ////[]
        ////[Display(Name = "Pick Up City")]
        //public string PickUpCity { get; set; }
        ////[]
        ////[Display(Name = "Pick Up State")]
        //public string PickUpState { get; set; }
        ////[]
        ////[Display(Name = "Pick Up Country")]
        //public string PickUpCountry { get; set; }
        //public string PickUpZipcode { get; set; }

        //[]
        //[Display(Name = "Delivery Facility Name")]
        //public string DeliveryFacilityName { get; set; }
        ////[]
        ////[Display(Name = "Delivery Address")]
        //public string DeliveryAddress { get; set; }
        ////[]
        ////[Display(Name = "Delivery City")]
        //public string DeliveryCity { get; set; }
        ////[]
        ////[Display(Name = "Delivery State")]
        //public string DeliveryState { get; set; }
        ////[]
        ////[Display(Name = "Delivery Country")]
        //public string DeliveryCountry { get; set; }

        //public string DeliveryZipcode { get; set; }

        //[]
        //[Display(Name = "Pick Up Time Begins")]
        //public DateTime PickUpTime1 { get; set; }
        //[]
        //[Display(Name = "Pick Up Time Ends")]
        //public DateTime PickUpTime2 { get; set; }
        //[]
        //[Display(Name = "Delivery Time Begins")]
        //public DateTime DeliveryTime1 { get; set; }
        //[]
        //[Display(Name = "Delivery Time Ends")]
        //public DateTime DeliveryTime2 { get; set; }

    }
}