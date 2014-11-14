using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_Project_Master.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        [Required]
        public string Lastname { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        [Required]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string County { get; set; }
        
    }
}