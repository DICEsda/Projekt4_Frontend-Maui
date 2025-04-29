using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;
using FinanceTrackerAPP.Views;


namespace FinanceTrackerAPP
{
    public partial class App : Microsoft.Maui.Controls.Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
             
            var navPage = new NavigationPage(new LoginPage());
            return new Window(navPage);
        }
    }
}
