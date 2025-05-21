using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FinanceTracker.Models;
using FinanceTracker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceTracker.Services.Interfaces;

namespace FinanceTracker.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {

        private readonly IAuthenticationService _authenticationService;

        public LoginViewModel(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string password;

        [RelayCommand]
        async Task Login()
        {
            LoginDTO financeUserDTO = new LoginDTO
            {
                Password = password,
                UserName = email
            };
            var token = await _authenticationService.Login(financeUserDTO);
            try
            {
                if (token != null)
                {
                    await Shell.Current.GoToAsync("//DashboardPage");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        [RelayCommand]
        async Task NavigateToRegisterPage()
        {
            await Shell.Current.GoToAsync("//RegisterPage");
        }


    }
}