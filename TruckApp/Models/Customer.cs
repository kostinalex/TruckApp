using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TruckApp.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Customer Name.")]
        [Display(Name = "Customer Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter Customer Address.")]
        [Display(Name = "Customer Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter Customer City.")]
        [Display(Name = "Customer City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter Customer State.")]
        [Display(Name = "Customer State")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please enter Customer Country.")]
        [Display(Name = "Customer Country")]
        public string Country { get; set; }

        public string Zipcode { get; set; }
        public bool Void { get; set; }
    }
}