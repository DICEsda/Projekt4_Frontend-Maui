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
        public Task<JobDTO> RegisterJobAsync(JobDTO jobDTO);
    }
}
