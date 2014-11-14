using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace Web_Project_Master.Models
{
    public class ProductDb:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategorys { get; set; }
        public DbSet<ProductImages> Images { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerLogin> CustomerLogin { get; set; }
        public DbSet<AdminLogin> AdminLogin { get; set; }
        public ProductDb()
            : base("ProductDb")
        {

        }


    }
}