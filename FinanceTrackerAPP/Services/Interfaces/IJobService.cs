using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceTracker.Models;

namespace FinanceTracker.Services.Interfaces
{
    public interface IJobService
    {
        Task<JobDTO> RegisterJobAsync(JobDTO jobDTO);
        Task<List<JobDTO>> GetAllJobsAsync();
        Task DeleteJobAsync(string companyName);
        Task<JobDTO> UpdateJobAsync(JobDTO jobDTO, string companyName);

    }
}
