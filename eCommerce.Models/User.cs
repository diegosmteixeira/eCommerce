using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Gender { get; set; }
        public string? RG { get; set; }
        public string? CPF { get; set; }
        public string? MotherName { get; set; }
        public string? RegisterSituation { get; set; }
        public DateTimeOffset RegisterDate { get; set; }
        public Contact? Contact { get; set; }
        public ICollection<DeliveryAddress>? DeliveryAddresses { get; set; }
        public ICollection<Department>? Departments { get; set; }

        /*
         * TODO - Class vinculation 
         * - Contact
         * - DeliveryAddress
         * - Department
         */
    }
}