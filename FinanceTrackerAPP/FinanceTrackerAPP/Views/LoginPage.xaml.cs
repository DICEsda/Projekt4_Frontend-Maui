using FinanceTrackerAPP.ViewModels;

namespace FinanceTrackerAPP.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
        }
    }
}
