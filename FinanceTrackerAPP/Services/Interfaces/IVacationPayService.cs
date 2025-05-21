using FinanceTracker.DTO;

namespace FinanceTracker.Services.Interfaces
{
    public interface IVacationPayService
    {
        Task<VacationPayDTO> GetVacationPay(string companyName, int year);
    }
}