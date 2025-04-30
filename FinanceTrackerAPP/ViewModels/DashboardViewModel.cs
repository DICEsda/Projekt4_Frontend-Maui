using System;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;

namespace FinanceTracker.ViewModels
{

    public partial class DashboardViewModel : ObservableObject
    {
        [RelayCommand]
        async Task Logout()
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }

    }
}