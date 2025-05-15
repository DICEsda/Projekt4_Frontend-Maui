using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FinanceTracker.Models;
using FinanceTracker.Services.Interfaces;
using FinanceTracker.Services;
using FinanceTracker.Views;
using System.Threading.Tasks;
using FinanceTracker.DTO;
namespace FinanceTracker.ViewModels
{

    public partial class JobsOverviewViewModel : ObservableObject
    {
        private readonly IJobService _jobService;

        public JobsOverviewViewModel(IJobService jobService)
        {
            _jobService = jobService;
            LoadJobsCommand = new AsyncRelayCommand(LoadJobsAsync);
            NavigateToAddJobCommand = new AsyncRelayCommand(NavigateToAddJobAsync);
        }

        [ObservableProperty]
        private ObservableCollection<JobDTO> jobs = new();

        public IAsyncRelayCommand LoadJobsCommand { get; }
        public IAsyncRelayCommand NavigateToAddJobCommand { get; }

        private async Task LoadJobsAsync()
        {
            var jobsList = await _jobService.GetAllJobsAsync();
            Jobs.Clear();
            foreach (var job in jobsList)
                Jobs.Add(job);
        }

        private async Task NavigateToAddJobAsync()
        {
            await Shell.Current.GoToAsync(nameof(JobsPage));
        }
    }
}