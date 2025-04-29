using FinanceTrackerAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTrackerAPP.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;


        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://yourapiurl.com/api/"); // Replace with your API URL
        }

        public async Task<FinanceUserDTO?> RegisterUserAsync(FinanceUserDTO financeUser)
        {
            var response = await _httpClient.PostAsJsonAsync("Account/Register", financeUser);

            if (response.IsSuccessStatusCode)
            {
                // Assuming the API returns the created user object in the response body
                return await response.Content.ReadFromJsonAsync<FinanceUserDTO>();
            }

            return null; // Return null if registration fails
        }

        public async Task<JobDTO> AddJob(JobDTO jobDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("Job/RegisterJob", jobDTO);

            if (response.IsSuccessStatusCode)
            {
                // Assuming the API returns the created user object in the response body
                return await response.Content.ReadFromJsonAsync<JobDTO>();
            }

            return null; // Return null if registration fails

        }

    }
}
