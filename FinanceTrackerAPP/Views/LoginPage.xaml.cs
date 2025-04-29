using FinanceTracker.ViewModels;
using FinanceTracker.Services;
using FinanceTracker.Services.Interfaces;


namespace FinanceTracker.Views
{
    public partial class LoginPage : ContentPage
    {
        private readonly IAuthenticationService _authenticationService;

        public LoginPage(IAuthenticationService authenticationService)
        {
            InitializeComponent();
            _authenticationService = authenticationService;
            BindingContext = new LoginViewModel(_authenticationService);
        }
    }
}