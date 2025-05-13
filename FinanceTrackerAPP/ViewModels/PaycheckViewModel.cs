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
using Microsoft.Maui.Graphics;


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

        [ObservableProperty]
        private Color salaryBeforeTaxIndicator;
        [ObservableProperty]
        private Color workedHoursIndicator;
        [ObservableProperty]
        private Color amContributionIndicator;
        [ObservableProperty]    
        private Color taxIndicator;
        [ObservableProperty]
        private Color salaryAfterTaxIndicator;


        [ObservableProperty]
        private string companyName;

        [ObservableProperty]
        private int month;

        [ObservableProperty]
        private decimal salaryBeforeTaxActual;
        [ObservableProperty]
        private double workedHoursActual;
        [ObservableProperty]
        private decimal amContributionActual;
        [ObservableProperty]
        private decimal taxActual;
        [ObservableProperty]
        private decimal salaryAfterTaxActual;

        [ObservableProperty]
        private string compareResult;

        [RelayCommand]
        async Task SalaryEstimationForMonth()
        {
            var payCheck = await _payCheckService.SalaryEstimationForMonth(companyName, month);
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

        [RelayCommand]
        async Task Compare()
        {
            bool result = true;
            if (salaryBeforeTaxActual == salaryBeforeTax) SalaryBeforeTaxIndicator = Colors.Green;
            else
            {
                result = false;
            SalaryBeforeTaxIndicator = Colors.Red;
            }


            if (workedHoursActual == workedHours) WorkedHoursIndicator = Colors.Green;
            else

            {
                result = false;
                WorkedHoursIndicator = Colors.Red;
            }

            if (AmContributionActual == AmContribution) AmContributionIndicator = Colors.Green;
            else

            {
                result = false;
                AmContributionIndicator = Colors.Red;
            }

            if (taxActual == tax) TaxIndicator = Colors.Green;
            else

            {
                result = false;
                TaxIndicator = Colors.Red;
            }

            if (salaryAfterTaxActual == salaryAfterTax) SalaryAfterTaxIndicator = Colors.Green;
            else
            {
                result = false;
                SalaryAfterTaxIndicator = Colors.Red;
            }

            if (result) CompareResult = "The paycheck is correct!";
            else CompareResult = "The paycheck is wrong, contact your employeer!";

        }


    }
}
