﻿using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using FinanceTracker.Models;
using FinanceTracker.Services;
using FinanceTracker.Views;
using System.Windows.Input;
using FinanceTracker.Services.Interfaces;
using System;

namespace FinanceTracker.ViewModels
{
    public partial class JobsViewModel : ObservableObject
    {
        private readonly IJobService _jobService;
        private readonly AuthHeaderHandler _authHeaderHandler;

        public JobsViewModel(IJobService jobService, AuthHeaderHandler authHeaderHandler)
        {
            _jobService = jobService;
            _authHeaderHandler = authHeaderHandler;
        }

        [ObservableProperty]
        private string title;

        [ObservableProperty]
        private string companyName;

        [ObservableProperty]
        private string employmentType;

        [ObservableProperty]
        private decimal hourlyRate;
        [ObservableProperty]
        private string taxCard;

        [RelayCommand]
        async Task RegisterJob()
        {

            var job = new JobDTO
            {
                Title = Title,
                CompanyName = CompanyName,
                EmploymentType = EmploymentType,
                HourlyRate = HourlyRate,
                TaxCard = TaxCard
            };

            var result = await _jobService.RegisterJobAsync(job);
        }




    }
}