using FinanceTracker.DTO;

namespace FinanceTracker.Services.Interfaces
{
    public interface ISupplementDetailService
    {
        Task<SupplementDetailsDTO> AddSupplementDetails(SupplementDetailsDTO supplementDetailsDTO,string companyName);
    }
}