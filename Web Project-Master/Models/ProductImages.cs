using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_Project_Master.Models
{
    public class ProductImages
    {
        [Key]
        public int ProductImageId { get; set; }
        [Required]
        public Product Product { get; set; }
        [Required]
        public string ImageUrl { get; set; }
    }
}