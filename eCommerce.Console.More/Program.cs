using eCommerce.API.Database;
using eCommerce.Models;
using Microsoft.EntityFrameworkCore;

var db = new eCommerceContext();
// var newUser = new User() { Name = "Philip", Email = "philip@gmail.com", 
//                            Gender = "M", MotherName = "Sarah", RG = "71.711.771",
//                            CPF = "111.111.111-11", RegisterSituation = "A",
//                            RegisterDate = DateTimeOffset.Now };

// db.Add(newUser);

// var newUser = db.Users!.Find(2);
// newUser.Name = "Philip Williams Brown";
// db.SaveChanges();

#region Global Filters
var users = db.Users!.IgnoreQueryFilters().ToList();

foreach(var user in users)
{
    Console.WriteLine($" - {user.Name}");
}
#endregion

#region Temporal Tables

Console.WriteLine("[ Temporal Tables ]");

// TemporalAsOf(AsOf) -> Be valid into a specific date
    // var AsOf = new DateTime(2022, 10, 11, 21, 21, 00);

// TemporalFromTo(From, To)
    // var From = new DateTime(2022, 10, 11, 21, 20, 00);
    // var To = new DateTime(2022, 10, 11, 21, 23, 00);

// TemporalBetween(From, To)

// TemporalContainedIn()  --> in a range

var userTemp = db.Users!
    .TemporalAll()
    .Where(u => u.Id == 2)
    .OrderBy(u => EF.Property<DateTime>(u, "StartTime"))
    .ToList();

foreach(var user in userTemp)
{
    Console.WriteLine($" - {user.Name} Mother: {user.MotherName}");
}


#endregion