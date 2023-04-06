using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Office
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        //EF Core 5.0 > Vehicle
        public ICollection<Vehicle>? Vehicles { get; set; }

        // (POO) If need access another properties like 'StartDate'
        public ICollection<EmployeeVehicle>? EmployeeVehicles { get; set; }

        public ICollection<EmployeeSection>? EmployeeSection { get; set; }
        public ICollection<TrainingClass>? TrainingClasses { get; set; }
    }
}