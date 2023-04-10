using System;
using eCommerce.API.Database;
using Microsoft.EntityFrameworkCore;

/*
 * EF Core -> Support LINQ > convert to pure SQL
 *
 *          (LINQ = query language)
 *
 * To*, First*, Single*, Last*, Count.. [ SQL ] --> App -> C# Memory
 *
 * db.Users.{Methods > LINQ > EF > SQL > SGDB}.ToList().{Methods > LINQ > C# > Processor+Memory}
 */

var db = new eCommerceContext();

// ToList(), ToArray(), ToHashSet(), ToDictionary(), etc
var users = db.Users!.ToList();

Console.WriteLine("- USERS LIST -");
foreach (var user in users)
{
    Console.WriteLine($" - {user.Name}");
}

#region Find()
Console.WriteLine("[ FIND BY ID ] ");

// Find(2 , 1) -- users and department
// Find("email@server.com")

var user01 = db.Users!.Find(6);

Console.WriteLine($" Primary Key: {user01.Id} Name: {user01.Name} ");
#endregion

#region First(), Last(), Find(), Single() - will show exception if has empty value -
var user02 = db.Users.Where(user => user.Name == "Mike AsNoTracking").First();

Console.WriteLine($" First Registry: {user02.Name} ");
#endregion

#region FirstOrDefault() - return NULL if not found
var user03 = db.Users.FirstOrDefault(user => user.Id == 2);
if (user03 == null)
{
    Console.WriteLine("User not found.");
}
else
{
    Console.WriteLine($" FirstOrDefault Id: 6 Name: {user03.Name}");
}
#endregion

#region  LastOrDefault() - it's needed use OrderBy before
var user04 = db.Users.OrderBy(users => users.Id).Where(user => user.Email == "e@email.com").LastOrDefault();

if(user04 == null)
{
    Console.WriteLine("User not found.");
}
else
{
    Console.WriteLine($" LastOrDefault() Name: {user04.Name}");
}
#endregion

#region SingleOrDefault() - if more than one registry => Exception 'Sequence contains more than one element'
var user05 = db.Users.SingleOrDefault(user => user.Name.Contains("z"));

if(user05 == null)
{
    Console.WriteLine("User not found.");
}
else
{
    Console.WriteLine($" SingleOrDefault() Name: {user04.Name}");
}
#endregion

#region Count(), Max(), Min()
var user06 = db.Users.Where(user => user.Name.Contains("a")).Count();

Console.WriteLine("Count: " + user06);

var max = db.Users.Max(user => user.Id);

var min = db.Users.Min(user => user.Name);

Console.WriteLine($"Max: {max} - Min: {min}");
#endregion

#region Where()
Console.WriteLine(" [ WHERE ] : ");
// var list = db.Users!.Where(user => user.Id == 1 || user.Name == "Mike AsNoTracking").ToList();

// [ LIKE - SQL ]
// var userList = db.Users!.Where(user => EF.Functions.Like(user.Name, "%a%")).ToList();

// [ StartsWith ]
// var userList = db.Users!.Where(user => user.Name.StartsWith("M")).ToList();

// [ EndsWith ]
var userList = db.Users!.Where(user => user.Name.EndsWith("d")).ToList();


foreach(var user in userList)
{
    Console.WriteLine($"- {user.Name}");
}
#endregion

#region OrderBy(), OrderByDescending(), ThenBy(), ThenByDescending()
Console.WriteLine(" [ ORDER BY ] : ");

// [ OrderBy alphabet ]
// var orderList = db.Users!.OrderBy(u => u.Name).ToList();

// [ OrderByDescending ]
// var orderList = db.Users!.OrderByDescending(u => u.Name).ToList();

// [ ThenBy ]
// var orderList = db.Users!.OrderBy(u => u.Gender).ThenBy(u => u.Name).ToList();

// [ ThenByDescending ]
var orderList = db.Users!.OrderBy(u => u.Gender).ThenByDescending(u => u.Name).ToList();

foreach(var user in orderList)
{
    Console.WriteLine($"- {user.Name}");
}
#endregion

#region Include(), ThenInclude(), AutoInclude()
Console.WriteLine("USERS LIST .INCLUDE()");

// var userListInclude = db.Users!.Include(user => user.Contact).ToList();
var userListInclude = db.Users!
    .Include(u => u.Contact)
    .Include(u => u.DeliveryAddresses.Where(a => a.State == "SP"))
    .Include(u => u.Departments)
    .ToList();

foreach(var user in userListInclude)
{
    Console.WriteLine($" - {user.Name}");
    foreach(var department in user.Departments)
    {
        Console.WriteLine($" {department.Name} -- Id: {department.Id}");
    }
}
Console.WriteLine("CONTACTS LIST .THENINCLUDE()");

// var userListInclude = db.Users!.Include(user => user.Contact).ToList();
var contacts = db.Contacts!
    .Where(c => c.Id == 1) // contacts that have user Id == 1
    .Include(c => c.User) // include all users
    .ThenInclude(u => u.DeliveryAddresses) // include delivery addreses
    .Include(u => u.User) // back to users to find departmets (EF will not do another JOIN)
    .ThenInclude(u => u.Departments) // include departments
    .ToList();

foreach(var contact in contacts)
{
    Console.WriteLine($" TEL: {contact.Telephone} - USER: {contact.User.Name} - ADDRESSES: {contact.User.DeliveryAddresses!.Count} - DEP: {contact.User.Departments.Count}");
}

db.ChangeTracker.Clear();

Console.WriteLine("LIST USING .AUTOINCLUDE()");
/*
 * AutoInclude setted at Context
 */
var usersAutoInclude = db.Users!
    .IgnoreAutoIncludes()  // when don't want AutoInclude()
    .ToList();

foreach(var user in usersAutoInclude)
{
    Console.WriteLine($"Name: {user.Name} - Contact: {user.Contact?.Telephone}");
}
#endregion

#region Explicit Load
/* ------------------
 *   Explict Load
 * ------------------
 */ // used when it's needed to load data that already be in the computer memory
db.ChangeTracker.Clear();

var userExplictLoad = db.Users!.IgnoreAutoIncludes().FirstOrDefault(u => u.Id == 1);

// Reference (load one Entity)
db.Entry(userExplictLoad).Reference(u => u.Contact).Load();

Console.WriteLine(userExplictLoad.Contact.Telephone);

// Collection (load a Collection)
db.Entry(userExplictLoad).Collection(u => u.DeliveryAddresses).Load();

Console.WriteLine(userExplictLoad.DeliveryAddresses?.Count);

// Query() returns IQueryable
var addresses = db.Entry(userExplictLoad).Collection(u => u.DeliveryAddresses)?.Query().Where(a => a.State == "SP").ToList();

foreach(var address in addresses)
{
    Console.WriteLine($" -- {address.Street}");
}
#endregion

#region Lazy Loading

// 1) [ With Proxies ]

Console.WriteLine("[ LAZY LOADING - With Proxies]");
db.ChangeTracker.Clear(); // memory clean

var userLazyLoad = db.Users!.Find(1);

Console.WriteLine($" LazyLoad - Name: {userLazyLoad!.Name} - Contact: {userLazyLoad.Contact?.Telephone}");

// ** Be careful with Lazy Load inside a foreach loop (each time that iterates, lazy will access the database) **

// 2) [ Without Proxies ]

Console.WriteLine("[ LAZY LOADING - Without Proxies]");
// ILazyLoader (EF Core)
// Delegate (Model -> without class coupling)

Console.WriteLine($" LazyLoad - Name: {userLazyLoad!.Name} - Contact: {userLazyLoad.Contact?.Cellphone}");
#endregion