using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Telephone { get; set; }
        public string? Cellphone { get; set; }

        // POO - Navigation
        public User? User { get; set; }
    }
}