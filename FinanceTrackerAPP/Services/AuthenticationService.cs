using FinanceTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using FinanceTracker.Services.Interfaces;

namespace FinanceTracker.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _httpClient;

        public AuthenticationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:5140/"); // Replace with your API URL
        }


        public async Task<string?> Login(LoginDTO loginDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("Account/Login", loginDTO);

            if (response.IsSuccessStatusCode)
            {

                var rawtoken = await response.Content.ReadAsStringAsync();
                var token = rawtoken.Trim('"');
                return token;
            }
            return null;
        }

    }
}