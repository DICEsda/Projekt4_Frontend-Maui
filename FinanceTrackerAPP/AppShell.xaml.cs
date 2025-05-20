using System.Diagnostics;
using FinanceTracker.Views;
using FinanceTracker.ViewModels;

namespace FinanceTracker;

public partial class AppShell : Shell
{
    public static AppShell? CurrentAppShell { get; private set; } = default!;

    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute("PayCheckPage", typeof(PayCheckPage));
        //Routing.RegisterRoute(nameof(NotesPage), typeof(NotesPage));
        //Routing.RegisterRoute(nameof(SignUpPage), typeof(SignUpPage));
        Routing.RegisterRoute("LoginPage", typeof(LoginPage));
        //Routing.RegisterRoute(nameof(SearchPage), typeof(SearchPage));
        Routing.RegisterRoute("JobsPage", typeof(JobsPage));
        Routing.RegisterRoute("DashboardPage", typeof(DashboardPage));
        Routing.RegisterRoute("LogHours", typeof(LogHours));
        Routing.RegisterRoute("RegisterPage", typeof(RegisterPage));
        Routing.RegisterRoute("SupplementDetailsPage", typeof(SupplementDetails));
        Routing.RegisterRoute("VacationPayPage", typeof(VacationPayPage));
        CurrentAppShell = this;
    }

    /// <summary>
    /// Logout
    /// </summary>
    private async void OnMenuItemClicked(object sender, EventArgs e)
    {
        await Current.GoToAsync("//LoginPage");
    }

    protected override void OnNavigating(ShellNavigatingEventArgs args)
    {
        base.OnNavigating(args);

        if (args.Current != null)
        {
            Debug.WriteLine($"AppShell: source={args.Current.Location}, target={args.Target.Location}");
        }
    }
}
