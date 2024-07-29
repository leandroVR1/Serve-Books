using Microsoft.AspNetCore.Mvc;
using ServerBook.Models;
using ServerBook.Services;
using System.Threading.Tasks;
using ServerBook.Models.Dtos;

namespace ServerBook.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiAuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public ApiAuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            if (model == null || string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
            {
                return BadRequest(new { message = "Email and password must be provided" });
            }

            var response = await _userService.Authenticate(model.Email, model.Password);

            if (!response.Success)
            {
                return BadRequest(new { message = response.Message });
            }

            return Ok(new { token = response.Data });
        }
    }
}