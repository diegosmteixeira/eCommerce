﻿using System;
using System.Collections.Generic;

namespace eCommerce.Console.Models
{
    public partial class Department
    {
        public Department()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}
