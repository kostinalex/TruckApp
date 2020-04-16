using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TruckApp.Models
{
    public class Delivery
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Delivery Facility Name.")]
        [Display(Name = "Delivery Facility Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter Delivery Address.")]
        [Display(Name = "Delivery Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter Delivery City.")]
        [Display(Name = "Delivery City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter Delivery State.")]
        [Display(Name = "Delivery State")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please enter Delivery Country.")]
        [Display(Name = "Delivery Country")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Please enter Delivery Time 1.")]
        [Display(Name = "Delivery Time 1")]
        public DateTime Time1 { get; set; }

        [Required(ErrorMessage = "Please enter Delivery Time 2.")]
        [Display(Name = "Delivery Time 2")]
        public DateTime Time2 { get; set; }



    }
}