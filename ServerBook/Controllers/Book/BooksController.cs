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
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly BookRepository _context;
        public BooksController(BookRepository context){
            _context = context;
        } 

        [HttpGet]
        [Route("api/[controller]")]
        public IEnumerable<Book> ListBooks(){
            return _context.GetBooks();

        }

        [HttpGet]
        [Route("api/Book/{id}")]
        public Book BookId(int id){
            return _context.GetBookId(id);
        }


        
    }
}