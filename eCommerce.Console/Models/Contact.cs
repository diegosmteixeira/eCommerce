using System;
using System.Collections.Generic;

namespace eCommerce.Console.Models
{
    public partial class Contact
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Telephone { get; set; }
        public string? Cellphone { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
