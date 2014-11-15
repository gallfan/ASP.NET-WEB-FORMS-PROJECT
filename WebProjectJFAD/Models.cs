using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebProjectJFAD
{
    public class ProductSubCategory
    {
        [Key]
        public int SubCatergoryID { get; set; }
        [Required]
        public string SubCategoryType { get; set; }
        [Required]
        public ProductCategory ProductCategory { get; set; }
    }

    public class ProductCategory
    {
        [Key]
        public int CatergoryID { get; set; }
        public string CategoryType { get; set; }
        public List<ProductSubCategory> SubCategories { get; set; }
    }

    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public ProductSubCategory SubCatergory { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string BrandName { get; set; }
        [Required]
        public int Stock { get; set; }
        public string MadeInCountry { get; set; }
        public string Material { get; set; }
        public string Size { get; set; }
        public string Colour { get; set; }
    }

    public class OrderDetail
    {
        [Key]
        public int OderDetailId { get; set; }
        [Required]
        public Product Product { get; set; }
        [Required]
        public Order OrderId { get; set; }
        [Required]
        public int Quantity { get; set; }   
    }

    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public Customer Customer { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        public DateTime DueDate { get; set; }
        [Required]
        public decimal TotalDue { get; set; }
    }

    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        [Required]
        public string Lastname { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        [Required]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string County { get; set; }

    }

    public class CustomerLogin
    {
        [Key]
        public int CustomerLoginId { get; set; }
        [Required]
        public Customer Customer { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Passowrd { get; set; }
        public int Attempts { get; set; }
        public DateTime LastLoggedIn { get; set; }
    }

    public class AdminLogin
    {
        [Key]
        public int AdminId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }

    public class ProductImages
    {
        [Key]
        public int ProductImageId { get; set; }
        [Required]
        public Product Product { get; set; }
        [Required]
        public string ImageUrl { get; set; }
    }

    public class ProductDb : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategorys { get; set; }
        public DbSet<ProductImages> Images { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerLogin> CustomerLogins { get; set; }
        public DbSet<AdminLogin> AdminLogins { get; set; }
        public DbSet<ProductSubCategory> SubCategories { get; set; }
        public ProductDb()
            : base("ProductDb")
        {

        }
    }
}