using System;
using System.Collections.Generic;

namespace eCommerce.Console.Models
{
    public partial class User
    {
        public User()
        {
            DeliveryAddresses = new HashSet<DeliveryAddress>();
            Departments = new HashSet<Department>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Gender { get; set; }
        public string? Rg { get; set; }
        public string Cpf { get; set; } = null!;
        public string? MotherName { get; set; }
        public string? RegisterSituation { get; set; }
        public DateTimeOffset RegisterDate { get; set; }

        public virtual Contact? Contact { get; set; }
        public virtual ICollection<DeliveryAddress> DeliveryAddresses { get; set; }

        public virtual ICollection<Department> Departments { get; set; }
    }
}
