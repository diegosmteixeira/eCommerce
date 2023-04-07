using System;
using eCommerce.API.Database;
using eCommerce.Models;
using Microsoft.EntityFrameworkCore;

var db = new eCommerceContext();

#region Tracking()
// ------------------------------------------------------------------------------------
// 1st CASE:: Query Optimized ((Only Name will be updated)) because EF Core is tracking
// ------------------------------------------------------------------------------------
// Find() method is only usable on DbSet
var user01 = db.Users.Find(1); // EF will track this object
user01!.Name = "Mike Longfeet Tracked";

// db.Update() --> don't needed because EF Core is tracking
db.SaveChanges();
#endregion

#region NoTracking()
// ------------------------------------------------------------------------------------
// 2nd CASE:: Query not Optimized - ALL values will be updated
// ------------------------------------------------------------------------------------
// AsNoTracking() => EF change tracker (will not track obect)

var user02 = db.Users.AsNoTracking().FirstOrDefault(u => u.Id == 6);
user02!.Name = "Mike AsNoTracking";
db.Update(user02); // in this case is needed because EF core isn't tracking
db.SaveChanges();
#endregion

/* [NOTE]: do not use different approaches at same project */
// Compiler will identify one object as different objects if used at same time Tracking and AsNoTracking

// ChangeTrack.Clear() -> clean objects of memory that was tracked by Entity Framework
db.ChangeTracker.Clear();


#region Unit of Works

// Add, Update, Remove - operations stored until SaveChanges() is called

var user03 = new User() { Name = "Paul"};
db.Users.Add(user03);

var user04 = db.Users.Find(6);
user04!.Name = "Joseph Updated";
db.Users.Update(user04);

var user05 = db.Users.Find(1);
db.Users.Remove(user05);

// --------------------------------------------
// LongView => show debug with more information
// --------------------------------------------
Console.WriteLine(db.ChangeTracker.DebugView.LongView);

#endregion