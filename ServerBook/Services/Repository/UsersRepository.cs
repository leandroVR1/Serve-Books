using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using ServerBook.Services.Interfaces;
using ServerBook.Data;
using ServerBook.Models;

namespace ServerBook.Services.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly BaseContext _context;

        public UsersRepository(BaseContext context)
        {
            _context = context;
        }

        public User GetUser(string Email, string Password)
        {
            return _context.Users.FirstOrDefault(x => x.Email == Email && x.Password == Password);
        }
    }
}
