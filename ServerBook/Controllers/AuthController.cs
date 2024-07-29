using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServerBook.Models.Dtos;
using ServerBook.Services.Interfaces;

namespace ServerBook.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
       private readonly IJwtAuthenticationManager jwtAuthenticationManager;

        public AuthController(IJwtAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;

        }

        [HttpPost("login")]
        public IActionResult Authenticate([FromBody] LoginDto loginDto)
        {
            var token = jwtAuthenticationManager.Authenticate(loginDto.Email, loginDto.Password);
            if (token == null){
                return Unauthorized();
            }

            return Ok(new{Token = token});
            
          
        

        
        }
}
}