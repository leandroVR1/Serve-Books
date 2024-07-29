using Microsoft.AspNetCore.Mvc;
using ServerBook.Models.Dtos;
using ServerBook.Services.Interfaces;

namespace ServerBook.Controllers.Email
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {

        private readonly IEmailRepository _emailRepository;
        public EmailController(IEmailRepository emailRepository)
        {
            _emailRepository = emailRepository;
        }
        [HttpPost]
        public IActionResult SendEmail(EmailDto request)
        {
            _emailRepository.SendEmail(request);
            return Ok(request);
        }
    }
}