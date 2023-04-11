using eCommerce.API.Database;
using eCommerce.Models;
using Microsoft.EntityFrameworkCore;


#region Global Filters
var db = new eCommerceContext();
var users = db.Users!.IgnoreQueryFilters().ToList();

foreach(var user in users)
{
    Console.WriteLine($" - {user.Name}");
}
#endregion
