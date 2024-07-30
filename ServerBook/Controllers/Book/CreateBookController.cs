using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServerBook.Models;
using ServerBook.Services;

namespace ServerBook.Controllers
{
    [ApiController]
    public class CreateBookController : ControllerBase
    {
        private readonly BookRepository _context;
        public CreateBookController(BookRepository context){
            _context = context;
        } 
        
        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult PostBook([FromBody] Book book)
        {
            _context.CreateBook(book);
            return Ok("Usuario creado exitosamente");
        }
        
    }
}