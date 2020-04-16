using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace TruckApp.Models
{
    public class PickUp
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Pick Up Facility Name.")]
        [Display(Name = "Pick Up Facility Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter Pick Up Address.")]
        [Display(Name = "Pick Up Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter Pick Up City.")]
        [Display(Name = "Pick Up City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter Pick Up State.")]
        [Display(Name = "Pick Up State")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please enter Pick Up Country.")]
        [Display(Name = "Pick Up Country")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Please enter Pick Up Time 1.")]
        [Display(Name = "Pick Up Time 1")]
        public DateTime Time1 { get; set; }

        [Required(ErrorMessage = "Please enter Pick Up Time 2.")]
        [Display(Name = "Pick Up Time 2")]
        public DateTime Time2 { get; set; }
    }
}