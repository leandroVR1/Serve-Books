using Microsoft.AspNetCore.Http.HttpResults;
using ServerBook.Data;
using ServerBook.Models;

namespace ServerBook.Services
{
    public class UsersRepository : IUsersRepository
    {
         private readonly BaseContext _context;
        public UsersRepository(BaseContext context){
            _context = context;
        } 

        public void CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User GetUserId(int id)
        {
            return _context.Users.Find(id);
        }

        public IEnumerable<User> GetUsers()
        {
           return _context.Users.ToList();
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }
    }
}