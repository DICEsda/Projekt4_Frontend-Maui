using FinanceTrackerAPP.Models;

namespace FinanceTrackerAPP.Services
{
    public interface IUserService
    {
        Task<JobDTO> AddJob(JobDTO jobDTO);
        Task<FinanceUserDTO?> RegisterUserAsync(FinanceUserDTO financeUser);
    }
}