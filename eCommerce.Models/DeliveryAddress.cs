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
        public string? DeliveryName { get; set; }
        public string? ZipCode { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
        public string? District { get; set; }
        public string? Street { get; set; }
        public string? Number { get; set; }
        public string? Additional  { get; set; }
        public User? User { get; set; }
    }
}