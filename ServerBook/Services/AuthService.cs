using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using ServerBook.Data;
using ServerBook.Services.Errors;
using System.Threading.Tasks;

namespace ServerBook.Services
{
    public class UserService : IUserService
    {
        private readonly BaseContext _context;
        private readonly IConfiguration _configuration;
        private readonly ILogger<UserService> _logger;

        public UserService(BaseContext context, IConfiguration configuration, ILogger<UserService> logger)
        {
            _context = context;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<Response<string>> Authenticate(string email, string password)
        {
            try
            {
                var user = await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Email == email);

                if (user == null || user.Password != password)
                {
                    return new Response<string>("Invalid username or password", null, false);
                }

                var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name, user.Email),
                        new Claim(ClaimTypes.Role, user.Role?.Name)
                    }),
                    Expires = DateTime.UtcNow.AddHours(int.Parse(_configuration["Jwt:ExpirationHrs"] ?? "1")),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                return new Response<string>("Login success", tokenString, true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in Authenticate method");
                return new Response<string>("Internal server error", null, false);
            }
        }
    }
}