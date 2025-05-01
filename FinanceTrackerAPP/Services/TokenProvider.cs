using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceTracker.Services.Interfaces;

namespace FinanceTracker.Services
{
    public class TokenProvider : ITokenProvider
    {
        private const string TokenKey = "auth_token";

        public async Task<string?> GetTokenAsync()
        {
            return await SecureStorage.GetAsync(TokenKey);
        }
    }
}
