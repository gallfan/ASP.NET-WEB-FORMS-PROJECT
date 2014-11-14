using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_Project_Master.Models
{
    public class AdminLogin
    {
        [Key]
        public int AdminId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}