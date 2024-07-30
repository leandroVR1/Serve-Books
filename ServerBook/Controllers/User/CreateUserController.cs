using Microsoft.AspNetCore.Mvc;
using ServerBook.Models;
using ServerBook.Services;

namespace ServerBook.Controllers
{
    [ApiController]
    public class CreateUserController : Controller
    {
        
        private readonly UsersRepository _context;
        public CreateUserController(UsersRepository context){
            _context = context;
        } 

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult PostUser([FromBody] User user)
        {
            _context.CreateUser(user);
            return Ok("Usuario creado exitosamente");
        }
    }
}