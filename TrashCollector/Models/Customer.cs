using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Customer
    {
        public string name { get; set; }
        public string streetAddress { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int zipcode { get; set; }
        public bool isSuspended { get; set; }
        public string extraPickUpDate { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }

    }
}