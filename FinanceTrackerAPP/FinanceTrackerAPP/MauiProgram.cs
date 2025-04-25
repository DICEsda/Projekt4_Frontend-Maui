using Microsoft.Extensions.Logging;
using FinanceTrackerAPP.Views;
using FinanceTrackerAPP.ViewModels;
using FinanceTrackerAPP.Services;

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

            builder.Services.AddTransient<IAuthenticationService, AuthenticationService>();
            builder.Services.AddTransient<AuthHeaderHandler>();


            // Register HttpClient with AuthHeaderHandler for UserService
            builder.Services.AddHttpClient<IUserService, UserService>(client =>
            {
                client.BaseAddress = new Uri("https://yourapiurl.com/api/");
            }).AddHttpMessageHandler<AuthHeaderHandler>();


            // Register your pages and viewmodels here
            //   builder.Services.AddTransient<LogHours>();
            builder.Services.AddTransient<LogHoursViewModel>();
            builder.Services.AddTransient<add_editViewmodel>();
            builder.Services.AddTransient<MainPageViewModel>();
            builder.Services.AddTransient<RegisterViewModel>();



            // Ensure this line ends with parentheses and a semicolon

            return builder.Build();
        }
    }
}