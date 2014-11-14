using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_Project_Master.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public ProductCategory CatergoryId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string BrandName { get; set; }
        public int Stock { get; set; }
        public string MadeInCountry { get; set; }
        public string Material { get; set; }
        public string Size { get; set; }
        public string Colour { get; set; }
    }
}