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
    public class UpdateUserController : ControllerBase
    {
        private readonly UsersRepository _context;
        public UpdateUserController(UsersRepository context)
        {
            _context = context;
        }

        [HttpPut("api/[controller]/{id}")]
        public IActionResult PutUserId(int id, [FromBody] User user)
        {
            // Buscar el usuario en la base de datos
            var UserExistente = _context.GetUserId(id);

            if (UserExistente == null)
            {
                return NotFound("user no encontrado.");
            }

            UserExistente.Name = user.Name;
            UserExistente.RolId = UserExistente.RolId;
            UserExistente.Password = user.Password;
            UserExistente.Email = user.Email;

            try
            {
                _context.UpdateUser(UserExistente);
                return Ok("Actualizado correctamente");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar el user con ID: {id}. Detalles: {ex.Message}");
                return StatusCode(500, new { message = "Ocurrió un error al actualizar el cupón.", details = ex.Message });
            }


        }

    }
}