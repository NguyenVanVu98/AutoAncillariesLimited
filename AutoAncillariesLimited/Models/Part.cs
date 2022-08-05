using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoAncillariesLimited.Models
{
    public class Part
    {
        public int PartId { get; set; }
        [Display(Name = "Tên linh kiện")]
        [Required(ErrorMessage = "Không được để trống")]
        public string Name { get; set; }
        public int CarBrandId { get; set; }
        public int SupplierId { get; set; }
        public int ManufacturerId { get; set; }
        public int CategoryId { get; set; }
        public string CarName { get; set; }
        public float UnitPrice { get; set; }
        [Display(Name = "Mô tả")]
        [Required(ErrorMessage = "không được để trống")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public string Conditon { get; set; }
        public string Image { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        [Display(Name = "Số lượng hàng")]
        [Required(ErrorMessage = "số lượng hàng cần phải nhập")]
        [Range(0, 999999999, ErrorMessage = "Số lượng k hợp lệ")]
        public int QtyInStock { get; set; }
        public Category Category { get; set; }
        public CarBrand CarBrand { get; set; }
        public Supplier Supplier { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}