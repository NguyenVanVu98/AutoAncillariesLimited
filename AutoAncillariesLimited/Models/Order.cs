using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoAncillariesLimited.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd / MM / yyyy}")]
        [DefaultValue("getdate() ")]
        [DataType(DataType.Date)]
        [Display(Name = "Ngày đặt hàng")]
        public DateTime OrderDate { get; set; }
        public float Amount { get; set; }
        public Customer Customer { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}