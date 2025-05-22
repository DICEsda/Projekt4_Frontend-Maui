using System.Globalization;
using CommunityToolkit.Mvvm.ComponentModel;
using MyApp.Helpers;

namespace MyApp.Services;

public partial class TranslationService : ObservableObject
{
    public static TranslationService Instance { get; } = new();

    public string this[string key] => Localization.Get(key);

    public void Refresh()
    {
        // Notify all bindings that the values may have changed
        OnPropertyChanged(string.Empty); // Refresh all bound properties
    }


    public void SetCulture(string cultureCode)
    {
        var culture = new CultureInfo(cultureCode);

        Thread.CurrentThread.CurrentCulture = culture;
        Thread.CurrentThread.CurrentUICulture = culture;

        // Refresh bindings so UI updates
        Refresh();
    }
}
