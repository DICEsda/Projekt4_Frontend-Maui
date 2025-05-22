using System;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using System.Globalization;
using MyApp.Services;

namespace FinanceTracker.ViewModels
{

    public partial class DashboardViewModel : ObservableObject
    {
        [RelayCommand]
        async Task Logout()
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }

        [RelayCommand]
        async Task Job()
        {
            await Shell.Current.GoToAsync("//JobsPage");
        }


        [RelayCommand]
        async Task PayCheck()
        {
            await Shell.Current.GoToAsync("//PayCheckPage"); 
        }

        [RelayCommand]
        async Task LogHours()
        {
            await Shell.Current.GoToAsync("//LogHoursPage");
        }


        public ICommand LanguageCommand { get; }

        private bool _isDanish = true;

       // private void ToggleLanguage()
        //{
        //    var culture = _isDanish ? new CultureInfo("en") : new CultureInfo("da");
        //    Thread.CurrentThread.CurrentCulture = culture;
        //    Thread.CurrentThread.CurrentUICulture = culture;

        //    // Apply globally
        //    CultureInfo.DefaultThreadCurrentCulture = culture;
        //    CultureInfo.DefaultThreadCurrentUICulture = culture;

        //    _isDanish = !_isDanish;

        //}

        [RelayCommand]
        public void ToggleLanguage()
        {
            var current = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;

            var newCulture = current == "en" ? "da" : "en";

            TranslationService.Instance.SetCulture(newCulture);
        }
    }

}
