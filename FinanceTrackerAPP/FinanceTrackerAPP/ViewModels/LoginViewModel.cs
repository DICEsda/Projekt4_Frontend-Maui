using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FinanceTrackerAPP.DTO;
using FinanceTrackerAPP.Models;
using FinanceTrackerAPP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTrackerAPP.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {

        private readonly IAuthenticationService _authenticationService;

        public LoginViewModel(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [ObservableProperty]
        private string userName;

        [ObservableProperty]
        private string password;

        [RelayCommand]
        async Task Login()
        {
            LoginDTO financeUserDTO = new LoginDTO
            {
                Password = password,
                UserName = userName
            };
            var token = await _authenticationService.Login(financeUserDTO);



        }



    }
}
