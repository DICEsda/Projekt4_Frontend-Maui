using FinanceTrackerAPP.DTO;

namespace FinanceTrackerAPP.Services
{
    public interface IAuthenticationService
    {
        Task<string?> GetTokenAsync();
        Task<string> Login(LoginDTO loginDTO);
    }
}