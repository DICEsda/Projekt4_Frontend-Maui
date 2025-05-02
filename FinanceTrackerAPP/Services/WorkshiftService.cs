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
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoidGVzdHVzZXJAZXhhbXBsZS5jb20iLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJ0ZXN0dXNlckBleGFtcGxlLmNvbSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWVpZGVudGlmaWVyIjoiZTI5NDU3NDMtN2QwMC00YWZhLThmZDMtM2QyOThlOTIxMjlmIiwiZXhwIjoxNzQ2MjM5NDY4LCJpc3MiOiJNeUJHTGlzdCIsImF1ZCI6Ik15QkdMaXN0In0.Wk7o0QRUQ0hZ9zWq1PUy4HRw4MvthTnh6N93ZkJxknQ");

            var response = await _httpClient.PostAsJsonAsync("Workshifts", workshift);

            if (response.IsSuccessStatusCode) return await response.Content.ReadFromJsonAsync<WorkshiftDTO>();

            return null;
        }
        public async Task<List<WorkshiftDTO>> GetAllWorkShifts()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoidGVzdHVzZXJAZXhhbXBsZS5jb20iLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJ0ZXN0dXNlckBleGFtcGxlLmNvbSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWVpZGVudGlmaWVyIjoiZTI5NDU3NDMtN2QwMC00YWZhLThmZDMtM2QyOThlOTIxMjlmIiwiZXhwIjoxNzQ2MjM5NDY4LCJpc3MiOiJNeUJHTGlzdCIsImF1ZCI6Ik15QkdMaXN0In0.Wk7o0QRUQ0hZ9zWq1PUy4HRw4MvthTnh6N93ZkJxknQ");

            var response = await _httpClient.GetAsync("Workshifts");


            if (response.IsSuccessStatusCode) return await response.Content.ReadFromJsonAsync<List<WorkshiftDTO>>();

            return null;

        }


    }
}
