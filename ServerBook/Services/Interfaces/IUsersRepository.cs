using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerBook.Models;
using ServerBook.Models.Dtos;

namespace ServerBook.Services.Interfaces
{
    public interface IUsersRepository
    {
        User GetUser (string Email , string Password);
        Task<string> AgregarUsuarios(UserRegisterDto userRegisterDto);
    }
}