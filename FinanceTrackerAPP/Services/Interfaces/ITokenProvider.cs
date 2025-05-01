using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Services.Interfaces
{
    public interface ITokenProvider
    {
        Task<string> GetTokenAsync();
    }
}
