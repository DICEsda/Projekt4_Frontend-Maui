using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceTracker.DTO;

namespace FinanceTracker.Services.Interfaces
{
    public interface IPayCheckService
    {

        public Task<PayCheckDTO> SalaryEstimationForMonth(string companyName, int month);

    }
}
