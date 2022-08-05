using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoAncillariesLimited.Models
{
    public class Manufacturer
    {
        public int ManufacturerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public ICollection<Part> Parts { get; set; }
    }
}