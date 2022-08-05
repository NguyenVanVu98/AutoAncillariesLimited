using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoAncillariesLimited.Models
{
    public class CarBrand
    {
        public int CarBrandId { get; set; }
        public string Country { get; set; }
        public ICollection<Part> Parts { get; set; }
    }
}