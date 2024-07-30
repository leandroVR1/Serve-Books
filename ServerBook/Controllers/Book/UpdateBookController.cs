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
    public class UpdateBookController : ControllerBase
    {
        private readonly BookRepository _context;
        public UpdateBookController(BookRepository context){
            _context = context;
        } 
        
        [HttpPut("api/[controller]/{id}")]
        public IActionResult PutBookId(int id, [FromBody] Book book)
        {
            // Buscar el usuario en la base de datos
            var BookExistente = _context.GetBookId(id);

            if (BookExistente == null)
            {
                return NotFound("user no encontrado.");
            }

            BookExistente.Title = book.Title;
            BookExistente.AuthorId = BookExistente.AuthorId;
            BookExistente.GenderId = BookExistente.GenderId;
            BookExistente.PublicationDate = book.PublicationDate;
            BookExistente.NumberCopiesAvailable = book.NumberCopiesAvailable;
            BookExistente.Status = BookExistente.Status;
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