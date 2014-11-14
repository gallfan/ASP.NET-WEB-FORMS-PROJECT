using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_Project_Master.Models
{
    public class ProductCategory
    {
        [Key]
        public int CatergoryID { get; set; }
        public string CategoryType { get; set; }
    }
}