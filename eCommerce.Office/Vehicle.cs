using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Office
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LicensePlate { get; set; }
        public ICollection<Employee>? Employees { get; set; }
        public ICollection<EmployeeVehicle> EmployeeVehicles { get; set; }
    }
}