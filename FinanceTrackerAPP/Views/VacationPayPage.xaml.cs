using FinanceTracker.ViewModels;

namespace FinanceTracker.Views;

public partial class VacationPayPage : ContentPage
{
	public VacationPayPage(VacationPayViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}