using FinanceTrackerAPP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTrackerAPP.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _httpClient;

        private const string TokenKey = "auth_token";
        public AuthenticationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://yourapiurl.com/api/"); // Replace with your API URL
        }




        public async Task<string?> GetTokenAsync()
        {
            return await SecureStorage.GetAsync(TokenKey);
        }

        public async Task<string?> Login(LoginDTO loginDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("Account/Login", loginDTO);

            if (response.IsSuccessStatusCode)
            {

                var token = await response.Content.ReadAsStringAsync();
                await SecureStorage.SetAsync(TokenKey, token);
                return token;
            }
            return null;
        }

    }
}
