using FinanceTracker.ViewModels;

namespace FinanceTracker.Views;

public partial class SupplementDetails : ContentPage
{
	public SupplementDetails(SupplementDetailsViewModel supplementDetailsViewModel)
	{
		InitializeComponent();
		BindingContext = supplementDetailsViewModel;
	}
}