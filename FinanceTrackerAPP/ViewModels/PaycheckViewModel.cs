using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using FinanceTracker.DTO;
using FinanceTracker.Services;
using FinanceTracker.Services.Interfaces;

namespace FinanceTracker.ViewModels
{
    public partial class PayCheckViewModel : ObservableObject
    {
        private readonly IPayCheckService _payCheckService;
        private readonly AuthHeaderHandler _authHeaderHandler;

        public PayCheckViewModel(IPayCheckService payCheckService, AuthHeaderHandler authHeaderHandler)
        {
            _payCheckService = payCheckService;
            _authHeaderHandler = authHeaderHandler;
        }

        [ObservableProperty]
        private decimal salaryBeforeTax;
        [ObservableProperty]
        private double workedHours;
        [ObservableProperty]
        private decimal amContribution;
        [ObservableProperty]
        private decimal tax;
        [ObservableProperty]
        private decimal salaryAfterTax;

        [RelayCommand]
        async Task SalaryEstimationForMonth((string companyName, int month) input)
        {
            var payCheck = await _payCheckService.SalaryEstimationForMonth(input.companyName, input.month);
            if (payCheck == null)
            {
                return;
            }
            SalaryBeforeTax = payCheck.SalaryBeforeTax;
            WorkedHours = payCheck.WorkedHours;
            AmContribution = payCheck.AMContribution;
            Tax = payCheck.Tax;
            SalaryAfterTax = payCheck.SalaryAfterTax;
        }


    }
}
