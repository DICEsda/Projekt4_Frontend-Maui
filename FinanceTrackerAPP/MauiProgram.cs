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
                    fonts.AddFont("fa-solid-900.ttf", "FontAwesomeSolid");
                });

            // Register HttpClient
            // Register Services
            builder.Services.AddHttpClient();
            builder.Services.AddTransient<AuthHeaderHandler>();
            builder.Services.AddSingleton<IAuthenticationService, AuthenticationService>();
            builder.Services.AddSingleton<IUserService, UserService>();


            builder.Services.AddHttpClient<IPayCheckService, PayCheckService>()
                .AddHttpMessageHandler<AuthHeaderHandler>();


            builder.Services.AddHttpClient<IJobService, JobService>()
                .AddHttpMessageHandler<AuthHeaderHandler>();


            builder.Services.AddHttpClient<IWorkshiftService, WorkshiftService>()
                .AddHttpMessageHandler<AuthHeaderHandler>();




            // Register ViewModels
            builder.Services.AddSingleton<LoginViewModel>();
            builder.Services.AddSingleton<RegisterViewModel>();
            builder.Services.AddSingleton<JobsViewModel>();
            builder.Services.AddSingleton<JobsOverviewViewModel>();
            // Register other ViewModels as needed
            builder.Services.AddTransient<PayCheckViewModel>();
            builder.Services.AddTransient<PayCheckPage>();
            // Register Views
            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<JobsOverviewPage>();
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