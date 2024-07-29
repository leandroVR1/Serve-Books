using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServerBook.Models;
using ServerBook.Models.Dtos;
using ServerBook.Services;

namespace ServerBook.Controllers
{
    [ApiController]
    public class DeleteBookController : ControllerBase
    {
          private readonly BookRepository _context;
        public DeleteBookController(BookRepository context){
            _context = context;
        } 

        [HttpPatch("api/[controller]/{id}")]
        public IActionResult PatchBookId(int id, [FromBody] BookDto book)
        {
             var Book = new Book
            {
                Status = book.Status
            };

            // Buscar el usuario en la base de datos
            var BookExistente = _context.GetBookId(id);

            if (BookExistente == null)
            {
                return NotFound("user no encontrado.");
            }

            BookExistente.Status = Book.Status;

            try
            {
                _context.UpdateUser(BookExistente);
                return Ok("Actualizado correctamente");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar el libro con ID: {id}. Detalles: {ex.Message}");
                return StatusCode(500, new { message = "Ocurrió un error al actualizar el libro.", details = ex.Message });
            }


        }
    }
}