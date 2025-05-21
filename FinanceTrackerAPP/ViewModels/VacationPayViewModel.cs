using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FinanceTracker.Services.Interfaces;

namespace FinanceTracker.ViewModels
{
    public partial class VacationPayViewModel : ObservableObject
    {

        private readonly IVacationPayService vacationPayService;


        public VacationPayViewModel(IVacationPayService vacationPayService)
        {
            this.vacationPayService = vacationPayService;
        }

        [ObservableProperty]
        private string companyName;


        [ObservableProperty]
        private int year;


        [ObservableProperty]
        private decimal vacationPay;


        [RelayCommand]
        public async Task GetVacationPay()
        {
            try
            {
                var resp = await vacationPayService.GetVacationPay(CompanyName, Year);
                VacationPay = resp.VacationPay;
            }
            catch {
                VacationPay = -1;
            }

        }


    }
}
