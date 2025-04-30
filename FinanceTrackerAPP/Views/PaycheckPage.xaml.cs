using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceTracker.Services;
using FinanceTracker.ViewModels;

namespace FinanceTracker.Views;

public partial class PayCheckPage : ContentPage
{
    private PayCheckService payCheckService;
    private PayCheckViewModel payCheckViewModel;

    public PayCheckPage(PayCheckViewModel payCheckViewModel)
    {
        InitializeComponent();
        BindingContext =payCheckViewModel;
    }
    private async void OnFetchTapped(object sender, EventArgs e)
    {
        if (BindingContext is PayCheckViewModel vm)
        {
            string company = CompanyEntry.Text;
            int.TryParse(MonthEntry.Text, out int month);

            await vm.SalaryEstimationForMonthCommand.ExecuteAsync((company, month));
        }
    }

}