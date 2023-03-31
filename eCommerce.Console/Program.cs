using System;
using eCommerce.Console.Database;


var db = new eCommerceContext();
db.Users.ToList();


foreach(var user in db.Users)
{
    Console.WriteLine(user.Name);
}


Console.WriteLine("Hello, World!");
