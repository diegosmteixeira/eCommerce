using System;
using eCommerce.API.Database;

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

#region First(), Last() and Find() - will show exception if has empty value -
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

