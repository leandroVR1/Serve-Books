using System.Threading.Tasks;
using ServerBook.Services.Errors;

namespace ServerBook.Services
{
    public interface IUserService
    {
        Task<Response<string>> Authenticate(string Email, string password);
    }
}