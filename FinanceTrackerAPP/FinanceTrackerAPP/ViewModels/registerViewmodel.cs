using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FinanceTrackerAPP.Models;
using FinanceTrackerAPP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTrackerAPP.ViewModels
{
    public partial class RegisterViewModel : ObservableObject // Ensure the class inherits from ObservableObject
    {
        private readonly IUserService _userService;

        public RegisterViewModel(IUserService userService)
        {
            _userService = userService;
        }

        [ObservableProperty]
        private string fullName;



        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string password;



        [RelayCommand]
        async Task RegisterUser()
        {
            FinanceUserDTO financeUserDTO = new FinanceUserDTO
            {
                Email = email,
                Password = password,
                FullName = fullName

            };

            await _userService.RegisterUserAsync(financeUserDTO);


        }

    }




}