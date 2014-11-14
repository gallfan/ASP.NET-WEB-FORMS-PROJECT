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
        public Product ProductId { get; set; }
        public Order OrderId { get; set; }
        public int Quantity { get; set; }
        
    }
}