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
    public class VacationPayService : IVacationPayService
    {

        private readonly HttpClient _httpClient;

        public VacationPayService(HttpClient httpClient)
        {
            _httpClient = httpClient;
           
        }

        public async Task<VacationPayDTO> GetVacationPay(string companyName, int year)
        {
            var url = $"http://localhost:5140/Paychecks/VacationPay?companyName={companyName}&year={year}";
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
               return await response.Content.ReadFromJsonAsync<VacationPayDTO>();
            }
            else
            {
                throw new HttpRequestException($"Request failed with status code {response.StatusCode}");
            }
        }
    }
}
