using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_Project_Master.Models
{
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
}