using System.Net.Http.Json;
using FinanceTracker.DTO;
using FinanceTracker.Services.Interfaces;

namespace FinanceTracker.Services;

public class PayCheckService : IPayCheckService
{

    private readonly HttpClient _httpClient;
    public PayCheckService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("http://localhost:5140/");
    }

    public async Task<PayCheckDTO> SalaryEstimationForMonth(string companyName, int month)
    {
        var response = await _httpClient.GetAsync($"PayChecks?month={month}&companyName={companyName}");
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Failed to fetch paycheck data.");
        }
        var paycheck = await response.Content.ReadFromJsonAsync<PayCheckDTO>();
        return paycheck;
    }
}