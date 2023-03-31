using System;
using System.Collections.Generic;

namespace eCommerce.Console.Models
{
    public partial class DeliveryAddress
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
        public string? Additional { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
