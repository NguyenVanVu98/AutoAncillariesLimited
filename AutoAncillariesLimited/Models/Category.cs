using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoAncillariesLimited.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        [Display(Name = "Mô tả")]
        [Required(ErrorMessage = "không được để trống")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public virtual ICollection<Part> Parts { get; set; }
    }
}