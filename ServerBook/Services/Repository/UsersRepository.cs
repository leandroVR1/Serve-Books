using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using ServerBook.Services.Interfaces;
using ServerBook.Models.Dtos;
using ServerBook.Data;
using ServerBook.Models;
using ServerBook.Services.Errors;
using Microsoft.EntityFrameworkCore;

namespace ServerBook.Services.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly BaseContext _context;

        public UsersRepository(BaseContext context)
        {
            _context = context;
        }

        public async Task<string> AgregarUsuarios(UserRegisterDto userRegisterDto)
        {
            var response = new Response<string>();

            response.ValidarValorIgualANull(response, userRegisterDto, "El objeto userRegisterDto no puede ser nulo");

            // Validación de existencia de usuario
            User? consultation = await _context.Users.FirstOrDefaultAsync(c => c.Email == userRegisterDto.Email);

            // Validar si ya existe un usuario con el mismo correo
            response.ValidarValorDiferenteANull(response, consultation, "El correo ya tiene un usuario registrado");

            if (response.Success)
            {
                // Crear y agregar nuevo usuario
                User nuevoUsuario = userRegisterDto.ConvertirARegisterDto(userRegisterDto);
                _context.Users.Add(nuevoUsuario);
                await _context.SaveChangesAsync();
            }
            return response.ErrorMessage;
        }

        public User GetUser(string Email, string Password)
        {
            return _context.Users.FirstOrDefault(x => x.Email == Email && x.Password == Password);
        }
    }
}
