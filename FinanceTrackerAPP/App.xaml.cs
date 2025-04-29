using FinanceTracker.Services;
using FinanceTracker.Views;

namespace FinanceTracker;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		MainPage = new AppShell();
	}
}
