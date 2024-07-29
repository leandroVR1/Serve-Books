using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServerBook.Services;

namespace ServerBook.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeleteUserController : ControllerBase
    {
         private readonly UsersRepository _context;
        public DeleteUserController(UsersRepository context){
            _context = context;
        } 

        
    }
}