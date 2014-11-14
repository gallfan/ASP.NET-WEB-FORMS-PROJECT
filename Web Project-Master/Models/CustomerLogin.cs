using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_Project_Master.Models
{
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
}