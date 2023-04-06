using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerce.API.Database;
using eCommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly eCommerceContext _db;
        public UserRepository(eCommerceContext db)
        {
            _db = db;
        }
        
        public void Add(User user)
        {
            // Unit of Works (muliple operations at memory)
            // Local Memory - EF Core
            _db.Users.Add(user);

            // Memory > DB (transaction) = 'use network connection'
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            // Local Memory - EF Core
            _db.Users.Remove(Get(id));

            // Memory > DB (transaction) = 'use network connection'
            _db.SaveChanges();
        }

        public List<User> Get()
        {
            // OrderBy() before ToList() => db operation *preferable
            // OrderBy() after ToList() => .net c# operation
            var list = _db.Users
                .Include(u => u.Contact)
                .OrderBy(u => u.Id)
                .ToList();
            
            return list;
        }

        public User Get(int id)
        {
            return _db.Users
                .Include(u => u.Contact)
                .Include(u => u.DeliveryAddresses)
                .Include(u => u.Departments)
                .FirstOrDefault(u => u.Id == id)!;
        }

        public void Update(User user)
        {
            // Local Memory - EF Core
            _db.Users.Update(user);

            // Memory > DB
            _db.SaveChanges();
        }
    }
}