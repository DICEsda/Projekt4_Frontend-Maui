using FinanceTracker.Models;
using System.Threading.Tasks;

namespace FinanceTracker.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<string> Login(LoginDTO loginDTO);
    }
}