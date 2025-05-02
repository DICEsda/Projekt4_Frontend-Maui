using FinanceTracker.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var response = await _httpClient.PostAsJsonAsync("Paycheck/registerWorkshift", workshift);

            if (response.IsSuccessStatusCode) return await response.Content.ReadFromJsonAsync<WorkshiftDTO>();

            return null;
        }
        public async Task<List<WorkshiftDTO>> GetAllWorkShifts()
        {
            var response = await _httpClient.GetAsync("Paychecks");

            if (response.IsSuccessStatusCode) return await response.Content.ReadFromJsonAsync<List<WorkshiftDTO>>();

            return null;

        }


    }
}
