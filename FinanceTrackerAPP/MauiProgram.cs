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
using iText.Kernel.Pdf;

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


            builder.Services.AddHttpClient<IVacationPayService, VacationPayService>()
                .AddHttpMessageHandler<AuthHeaderHandler>();


            builder.Services.AddHttpClient<IWorkshiftService, WorkshiftService>()
                .AddHttpMessageHandler<AuthHeaderHandler>();

            builder.Services.AddHttpClient<ISupplementDetailService, SupplementDetailService>()
                .AddHttpMessageHandler<AuthHeaderHandler>();


            builder.Services.AddTransient<VacationPayViewModel>();
            builder.Services.AddTransient<SupplementDetailsViewModel>();
            // Register ViewModels
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<RegisterViewModel>();
            builder.Services.AddTransient<JobsViewModel>();
            // Register other ViewModels as needed
            builder.Services.AddTransient<PayCheckViewModel>();
            builder.Services.AddTransient<PayCheckPage>();
            builder.Services.AddTransient<VacationPayPage>();
            // Register Views
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<RegisterPage>();
            builder.Services.AddTransient<JobsPage>();
            // Register other Views as needed
            builder.Services.AddTransient<SupplementDetails>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}