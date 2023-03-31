using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Models
{
    public class DeliveryAddress
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string DeliveryName { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
        public string State { get; set; } = null!;
        public string City { get; set; } = null!;
        public string District { get; set; } = null!;
        public string Street { get; set; } = null!;
        public string? Number { get; set; }
        public string? Additional  { get; set; }
        public User? User { get; set; }
    }
}