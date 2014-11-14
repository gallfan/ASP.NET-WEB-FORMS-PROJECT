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
        public Product ProductId { get; set; }
        public int ImageId { get; set; }
        public string ImageUrl { get; set; }
    }
}