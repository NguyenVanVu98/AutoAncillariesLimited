using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AutoAncillariesLimited.Models
{
    public class MyContext : DbContext
    {
        public MyContext() : base("name=DefaultConnection")
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<CarBrand> CarBrands { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
