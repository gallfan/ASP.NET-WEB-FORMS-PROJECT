using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_Project_Master.Models
{
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
}