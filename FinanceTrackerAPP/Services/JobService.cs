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
            var response = await _httpClient.PostAsJsonAsync("/Jobs", jobDTO);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to register job.");
            }

            var job = await response.Content.ReadFromJsonAsync<JobDTO>();
            return job;
        }

        public async Task<List<JobDTO>> GetAllJobsAsync()
        {
            var response = await _httpClient.GetAsync("/Jobs");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to get jobs.");
            }
            var jobs = await response.Content.ReadFromJsonAsync<List<JobDTO>>();
            return jobs;
        }

        public async Task DeleteJobAsync(string companyName)
        {
            var response = await _httpClient.DeleteAsync($"/Jobs/{companyName}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to delete job.");
            }
            var job = await response.Content.ReadFromJsonAsync<JobDTO>();
        }

        public async Task<JobDTO> UpdateJobAsync(JobDTO jobDTO, string companyName)
        {

            var response = await _httpClient.PutAsJsonAsync($"/Jobs/{companyName}", jobDTO);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to update job.");
            }
            var job = await response.Content.ReadFromJsonAsync<JobDTO>();
            return job;
        }

    }
}
