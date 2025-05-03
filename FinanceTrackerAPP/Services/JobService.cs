using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using FinanceTracker.Models;
using FinanceTracker.Services.Interfaces;

namespace FinanceTracker.Services
{
    public class JobService : IJobService
    {
        private readonly HttpClient _httpClient;
        public JobService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:5140/");
        }

        public async Task<JobDTO> RegisterJobAsync(JobDTO jobDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("/Job", jobDTO);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to register job.");
            }

            var job = await response.Content.ReadFromJsonAsync<JobDTO>();
            return job;
        }
    }
}
