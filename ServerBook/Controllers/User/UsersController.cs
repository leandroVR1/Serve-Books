using Microsoft.AspNetCore.Mvc;
using ServerBook.Models;
using ServerBook.Services;

namespace ServerBook.Controllers
{
    [ApiController]
   
    public class UsersController : ControllerBase
    {
        private readonly UsersRepository _context;
        public UsersController(UsersRepository context){
            _context = context;
        } 

        [HttpGet]
        [Route("api/[controller]")]
        public IEnumerable<User> ListUsers(){
            return _context.GetUsers();

        }

        [HttpGet]
        [Route("api/User/{id}")]
        public User UserId(int id){
            return _context.GetUserId(id);
        }


    }
}