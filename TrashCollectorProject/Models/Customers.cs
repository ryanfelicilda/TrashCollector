using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollectorProject.Models
{
    public class Customers
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string firstName { get; set; }

        [Display(Name = "Last Name")]
        public string lastName { get; set; }

        [Display(Name = "Street Address")]
        public string streetAddress { get; set; }

        [Display(Name = "City")]
        public string city { get; set; }

        [Display(Name = "State")]
        public string state { get; set; }

        [Display(Name = "Zip Code")]
        public int zipCode { get; set; }

        [Display(Name = "Balance")]
        public double balance { get; set; }

        [Display(Name = "Start Date for Pick-up")]
        public string startPickupDate { get; set; }

        [Display(Name = "Pickup Day (Ex. Monday)")]
        public string pickupDay { get; set; }

        [Display(Name = "End Date Pickup Date")]
        public string endPickupDate { get; set; }

        [Display(Name = "Extra Pickup Date")]
        public string extraPickupDate { get; set; }

        public bool confirmPickup { get; set; }

        
        [ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}