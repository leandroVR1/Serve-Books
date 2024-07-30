using Microsoft.AspNetCore.Mvc;
using ServerBook.Services;
using ServerBook.Models;

namespace ServerBook.Controllers
{
    [ApiController]
    public class CreateLoanController : Controller
    {

        private readonly LoanRepository _context;
        public CreateLoanController(LoanRepository context){
            _context = context;
        } 

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult PostLoan([FromBody] Loan loan)
        {
            
            _context.CreateLoan(loan);
            return Ok("Prestamo creado exitosamente");
        }
    }
}