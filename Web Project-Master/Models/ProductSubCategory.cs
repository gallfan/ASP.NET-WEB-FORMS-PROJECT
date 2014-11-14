using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_Project_Master.Models
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
}