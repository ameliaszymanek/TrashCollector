using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        [ForeignKey("Zipcode")]
        public int Zipcode { get; set; }
        public bool IsSuspended { get; set; }
        public double Balance { get; set; }
        public string PickUpDay { get; set; }
        public string ExtraPickUpDate { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}