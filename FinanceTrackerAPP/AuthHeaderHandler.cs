using FinanceTracker.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceTracker.Services;

namespace FinanceTracker
{
    public class AuthHeaderHandler : DelegatingHandler
    {


        public AuthHeaderHandler()
        {
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Retrieve the token from the authentication service
            var token = await SecureStorage.GetAsync("auth_token");

            if (!string.IsNullOrEmpty(token))
            {
                // Add the token to the Authorization header
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
