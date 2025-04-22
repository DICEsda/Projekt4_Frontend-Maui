using FinanceTrackerAPP.ViewModels;

namespace FinanceTrackerAPP.Views;

public partial class Add_Edit : ContentPage
{
	public Add_Edit()
	{
		InitializeComponent();
        BindingContext = new add_editViewmodel();
    }
}