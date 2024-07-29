using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerBook.Models;

namespace ServerBook.Services.Interfaces
{
    public interface IAuthService
    {
        string GenereteJwtToken (User user);
        
    }
}