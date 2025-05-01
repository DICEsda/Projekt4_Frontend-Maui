using FinanceTracker.Models;
using FinanceTracker.Services;
using FinanceTracker.Services.Interfaces;
using FinanceTracker.ViewModels;
using FinanceTracker.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using System;
using System.Net.Http;
namespace FinanceTracker
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

            // Register HttpClient
            // Register Services
            builder.Services.AddSingleton<ITokenProvider, TokenProvider>();
            builder.Services.AddHttpClient();
            builder.Services.AddTransient<AuthHeaderHandler>();
            builder.Services.AddHttpClient<IAuthenticationService, AuthenticationService>()
                .AddHttpMessageHandler<AuthHeaderHandler>();
            builder.Services.AddHttpClient<IPayCheckService, PayCheckService>()
                .AddHttpMessageHandler<AuthHeaderHandler>();


            // Register generic IDataStore
            builder.Services.AddSingleton<IDataStore<JobDTO>, JobDataStore>();

            // Register ViewModels
            builder.Services.AddSingleton<LoginViewModel>();
            builder.Services.AddSingleton<RegisterViewModel>();
            builder.Services.AddSingleton<JobsViewModel>();
            // Register other ViewModels as needed
            builder.Services.AddTransient<PayCheckViewModel>();
            builder.Services.AddTransient<PayCheckPage>();
            // Register Views
            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<RegisterPage>();
            builder.Services.AddSingleton<JobsPage>();
            // Register other Views as needed

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}