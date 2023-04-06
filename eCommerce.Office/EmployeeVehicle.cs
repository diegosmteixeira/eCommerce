using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Office
{
    public class EmployeeVehicle
    {
        /*MER*/
        public int EmployeeId { get; set; }
        public int VehicleId { get; set; }

        public DateTimeOffset StartDate { get; set; }

        /*POO*/
        public Employee Employee { get; set; } = null!;
        public Vehicle Vehicle { get; set; } = null!;

    }
}