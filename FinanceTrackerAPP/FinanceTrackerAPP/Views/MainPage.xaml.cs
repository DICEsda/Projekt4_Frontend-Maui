using FinanceTrackerAPP.ViewModels;
namespace FinanceTrackerAPP.Views;

public partial class Mainpage : ContentPage
{
	public Mainpage()
	{
		InitializeComponent();
        BindingContext = new MainPageViewModel();
    }
}