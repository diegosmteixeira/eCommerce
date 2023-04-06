using System;
using eCommerce.Office;
using Microsoft.EntityFrameworkCore;
using System.Linq;

// Context instance
var db = new eCommerceOfficeContext();

#region [Many-To-Many]: 2x One-To-Many <= [ EF Core 3.1-- ]

// Section >> EmployeeSection >> Employee
var result = db.Sections.Include(x => x.EmployeeSection)
                        .ThenInclude(x => x.Employee);

foreach (var section in result)
{
    Console.WriteLine(section.Name);

    foreach (var employeeSection in section.EmployeeSection)
    {
        Console.WriteLine(employeeSection.SectionId + " - " + 
                          employeeSection.EmployeeId + " - " +
                          employeeSection.Employee.Name);
    }
}
#endregion

#region Many-To-Many for [ EF Core 5.0++ ]
// Include => first level; ThenInclude => second level of relationship;
var result2 = db.Employees.Include(e => e.TrainingClasses);

foreach (var employee in result2)
{
    Console.WriteLine(" -- " + employee.Name + " -- ");
    foreach (var item in employee.TrainingClasses)
    {
        Console.WriteLine("." + item.Name);
    }
}
#endregion

Console.WriteLine();

#region Many-To-Many + Payload for EmployeeVehicles [ EF Core 5.0++ ]
var employeeVehicles = db.Employees.Include(v => v.Vehicles).ThenInclude(ev => ev.EmployeeVehicles);

foreach (var employee in employeeVehicles)
{
    Console.WriteLine($" [ {employee.Name} ] ");
    foreach(var vehicle in employee.Vehicles)
    {
        Console.WriteLine($" (vehicle): {vehicle.Name} (license-plate): {vehicle.LicensePlate}");
    }
}

foreach (var employee in employeeVehicles)
{
    Console.WriteLine($" [ {employee.Name} ] ");
    foreach(var ev in employee.EmployeeVehicles)
    {
        Console.WriteLine($" (vehicle): {ev.Vehicle.Name} (license-plate): {ev.Vehicle.LicensePlate} (start-date): {ev.StartDate}");
    }
}
#endregion

#region DbSet EmployeesVehicles
var line01 = db.Set<EmployeeVehicle>().SingleOrDefault(ev => ev.EmployeeId == 1 && ev.VehicleId == 1);
Console.WriteLine(line01.StartDate);

#endregion