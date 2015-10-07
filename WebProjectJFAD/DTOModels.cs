using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebProjectJFAD
{
    public class ProductDTO
    {
        //[Key]
        [Required]
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
}