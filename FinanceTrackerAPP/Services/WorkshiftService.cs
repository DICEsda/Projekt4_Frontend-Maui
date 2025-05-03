using FinanceTracker.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Services
{
    public class WorkshiftService : IWorkshiftService
    {
        private readonly HttpClient _httpClient;

        public WorkshiftService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:5140/");
        }
        public async Task<WorkshiftDTO> AddWorkShift(WorkshiftDTO workshift)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("auth_token"));
            var response = await _httpClient.PostAsJsonAsync("Workshifts", workshift);

            if (response.IsSuccessStatusCode) return await response.Content.ReadFromJsonAsync<WorkshiftDTO>();

            return null;
        }
        public async Task<List<WorkshiftDTO>> GetAllWorkShifts()
        {
            //waiting for automatic token insertion into header
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("auth_token"));
            var response = await _httpClient.GetAsync("Workshifts");


            if (response.IsSuccessStatusCode) return await response.Content.ReadFromJsonAsync<List<WorkshiftDTO>>();

            return null;

        }


    }
}
