using FinanceTracker.DTO;

namespace FinanceTracker.Services
{
    public interface IWorkshiftService
    {
        Task<WorkshiftDTO> AddWorkShift(WorkshiftDTO workshift);
        Task<List<WorkshiftDTO>> GetAllWorkShifts();
    }
}