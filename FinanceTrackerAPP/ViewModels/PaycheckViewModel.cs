using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using FinanceTracker.DTO;
using FinanceTracker.Services;

namespace FinanceTracker.ViewModels
{
    public partial class PayCheckViewModel : ObservableObject
    {
        private readonly PayCheckService _payCheckService;
        private readonly AuthHeaderHandler _authHeaderHandler;

        public PayCheckViewModel(PayCheckService payCheckService, AuthHeaderHandler authHeaderHandler)
        {
            _payCheckService = payCheckService;
            _authHeaderHandler = authHeaderHandler;
        }

        [ObservableProperty]
        private decimal salaryBeforeTax;
        [ObservableProperty]
        private TimeSpan workedHours;
        [ObservableProperty]
        private decimal amContribution;
        [ObservableProperty]
        private decimal tax;

        [RelayCommand]
        async Task SalaryEstimationForMonth((string companyName, int month) input)
        {
            var tester = await _authHeaderHandler.SendAsync();
            var payCheck = await _payCheckService.SalaryEstimationForMonth(input.companyName, input.month);
            if (payCheck == null)
            {
                return;
            }
            SalaryBeforeTax = payCheck.SalaryBeforeTax;
            WorkedHours = payCheck.WorkedHours;
            AmContribution = payCheck.AMContribution;
            Tax = payCheck.Tax;
        }


    }
}
