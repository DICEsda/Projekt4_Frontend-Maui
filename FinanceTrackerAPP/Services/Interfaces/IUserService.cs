using FinanceTracker.Models;
using System.Threading.Tasks;

namespace FinanceTracker.Services.Interfaces
{
    public interface IUserService
    {
        Task<JobDTO> AddJob(JobDTO jobDTO);
        Task<FinanceUserDTO?> RegisterUserAsync(FinanceUserDTO financeUser);
    }
}