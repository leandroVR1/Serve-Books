using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerBook.Models;

namespace ServerBook.Services
{
    public interface IUsersRepository
    {
        void CreateUser(User user);
        void UpdateUser(User user);
        IEnumerable<User> GetUsers();
        User GetUserId(int id);

    }
}