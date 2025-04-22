using FinanceTrackerAPP.ViewModels;
namespace FinanceTrackerAPP.Views;

public partial class Mainpage : ContentPage
{
	private readonly MainPageViewModel _viewModel;
	
	public Mainpage()
	{
		InitializeComponent();
		_viewModel = new MainPageViewModel();
		BindingContext = _viewModel;
	}
	
	private async void OnLogoutClicked(object sender, EventArgs e)
	{
		// Implement logout functionality
		await DisplayAlert("Logout", "You have been logged out", "OK");
		await Shell.Current.GoToAsync("//Register");
	}
	
	private async void OnUserClicked(object sender, EventArgs e)
	{
		await DisplayAlert("User Profile", "User profile will be shown here", "OK");
	}
	
	private void OnJobOverviewClicked(object sender, EventArgs e)
	{
		_viewModel.JobOverviewCommand.Execute(null);
	}
	
	private void OnLogHoursClicked(object sender, EventArgs e)
	{
		_viewModel.LogHoursCommand.Execute(null);
	}
	
	private void OnPaycheckClicked(object sender, EventArgs e)
	{
		_viewModel.PaycheckCommand.Execute(null);
	}
	
	private void OnHolidayPayClicked(object sender, EventArgs e)
	{
		_viewModel.HolidayPayCommand.Execute(null);
	}
	
	private void OnStudentGrantClicked(object sender, EventArgs e)
	{
		_viewModel.StudentGrantCommand.Execute(null);
	}
	
	private void OnLanguageToggleClicked(object sender, EventArgs e)
	{
		DisplayAlert("Language", "Language toggle functionality will be implemented", "OK");
	}
}