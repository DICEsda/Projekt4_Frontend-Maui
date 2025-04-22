using Microsoft.Extensions.Logging;
using FinanceTrackerAPP.Views;
using FinanceTrackerAPP.ViewModels;

namespace FinanceTrackerAPP
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            // Register your pages and viewmodels here
            builder.Services.AddTransient<LogHours>();
            builder.Services.AddTransient<LogHoursViewModel>();
            builder.Services.AddTransient<add_editViewmodel>();
            builder.Services.AddTransient<MainPageViewModel>();
            builder.Services.AddTransient<registerViewmodel>();
            return builder.Build();
        }
    }
}