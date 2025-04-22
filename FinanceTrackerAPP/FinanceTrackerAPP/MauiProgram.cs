using Microsoft.Extensions.Logging;
using FinanceTrackerAPP.Views;
using FinanceTrackerAPP.ViewModels;
using Microsoft.Maui.LifecycleEvents;

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
                })
                .ConfigureLifecycleEvents(events =>
                {
#if WINDOWS
                    events.AddWindows(windows => windows
                        .OnLaunched((app, args) => 
                        {
                            // Windows specific initialization logic
                        }));
#endif
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            // Register your pages and viewmodels here
            builder.Services.AddTransient<Loghours>();
            builder.Services.AddTransient<LogHoursViewModel>();
            builder.Services.AddTransient<add_editViewmodel>();
            builder.Services.AddTransient<MainPageViewModel>();
            builder.Services.AddTransient<registerViewmodel>();
            return builder.Build();
        }
    }
}