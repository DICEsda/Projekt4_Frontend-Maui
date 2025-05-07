using FinanceTracker.Services;
using FinanceTracker.ViewModels;

namespace FinanceTracker.Views;

public partial class LogHours : ContentPage
{
    public LogHours()
    {
        InitializeComponent();
        BindingContext = new LogHoursViewModel(new WorkshiftService(new HttpClient()));
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is LogHoursViewModel vm)
        {
            await vm.InitializeCalendar();
        }
    }
}