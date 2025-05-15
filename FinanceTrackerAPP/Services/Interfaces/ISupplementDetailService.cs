using FinanceTracker.DTO;

namespace FinanceTracker.Services.Interfaces
{
    public interface ISupplementDetailService
    {
        Task<List<SupplementDetailsDTO>> AddSupplementDetails(List<SupplementDetailsDTO> supplementDetailsDTO,string companyName);
    }
}