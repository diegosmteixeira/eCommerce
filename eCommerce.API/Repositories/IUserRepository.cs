using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerce.Models;

namespace eCommerce.API.Repositories
{
    public interface IUserRepository
    {
        List<User> Get();
        User Get(int id);
        void Add(User user);
        void Update(User user);
        void Delete(int id);
    }
}