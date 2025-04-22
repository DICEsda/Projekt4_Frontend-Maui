using FinanceTrackerAPP.ViewModels;

namespace FinanceTrackerAPP.Views;

public partial class Loghours : ContentPage
{
	public Loghours()
	{
		InitializeComponent();
        BindingContext = new LogHoursViewModel();
    }
}