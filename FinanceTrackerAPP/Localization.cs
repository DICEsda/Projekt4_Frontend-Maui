using System.Globalization;
using System.Resources;

namespace MyApp.Helpers;

public static class Localization
{
    private static readonly ResourceManager ResourceManager = new ResourceManager("FinanceTracker.Resources.Strings.Resources", typeof(Localization).Assembly);

    public static string Get(string key)
    {
        return ResourceManager.GetString(key, CultureInfo.CurrentUICulture) ?? $"[{key}]";
    }
}
