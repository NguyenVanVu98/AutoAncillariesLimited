using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoAncillariesLimited.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int PartId { get; set; }
        [Display(Name = "Số lượng hàng")]
        [Required(ErrorMessage = "số lượng hàng cần phải nhập")]
        [Range(0, 999999999, ErrorMessage = "Số lượng k hợp lệ")]
        public int Quantity { get; set; }
        public float UnitPrice { get; set; }
        public Order Order { get; set; }

        public Part Part { get; set; }
    }
}
