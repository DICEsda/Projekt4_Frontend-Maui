using FinanceTracker.Services.Interfaces;
using FinanceTracker.ViewModels;

namespace FinanceTracker.Views
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage(IUserService userService)
        {
            InitializeComponent();
            BindingContext = new RegisterViewModel(userService);
        }
    }
}
