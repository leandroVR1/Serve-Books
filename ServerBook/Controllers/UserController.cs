using Microsoft.AspNetCore.Mvc;
using ServerBook.Models.Dtos;
using ServerBook.Services.Interfaces;

namespace ServerBook.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUsersRepository _repository;

        public UserController(IUsersRepository repository)
        {
            _repository = repository;
        }
        [HttpPost]
        public async Task<IActionResult> AgregarUsuario([FromBody]  UserRegisterDto userRegisterDto)
        {
            var response  = await _repository.AgregarUsuarios(userRegisterDto);
            if (!ModelState.IsValid)
            {
                return BadRequest("Modelo no valido");
            }

            return Ok(response);
        }
    }
}