using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using FinanceTracker.DTO;
using FinanceTracker.Services.Interfaces;

namespace FinanceTracker.Services
{
    public class SupplementDetailService : ISupplementDetailService
    {

        private readonly HttpClient _httpClient;

        public SupplementDetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:5140/");
        }

        public async Task<List<SupplementDetailsDTO>> AddSupplementDetails(List<SupplementDetailsDTO> supplementDetailsDTO, string companyName)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("auth_token"));
            var response = await _httpClient.PostAsJsonAsync($"SupplementDetails/?companyName={companyName}", supplementDetailsDTO);

            if (response.IsSuccessStatusCode) return await response.Content.ReadFromJsonAsync<List<SupplementDetailsDTO>>();

            return null;

        }

    }
}
