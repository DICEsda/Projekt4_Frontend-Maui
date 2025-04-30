using FinanceTracker.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker
{
    public class AuthHeaderHandler : DelegatingHandler
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthHeaderHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Retrieve the token from the authentication service
            var token = await _authenticationService.GetTokenAsync();

            if (!string.IsNullOrEmpty(token))
            {
                // Add the token to the Authorization header
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
