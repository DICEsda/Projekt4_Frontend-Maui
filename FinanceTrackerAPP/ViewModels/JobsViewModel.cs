using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using FinanceTracker.Models;
using FinanceTracker.Services;
using FinanceTracker.Views;
using System.Windows.Input;

namespace FinanceTracker.ViewModels
{
    public partial class JobsViewModel : ObservableObject
    {
        // Declare the Jobs property
        public ObservableCollection<Job> Jobs { get; set; }

        // Declare the CurrentJob property
        public Job CurrentJob { get; set; }

        // Declare the EmploymentTypes list for the Picker
        public ObservableCollection<string> EmploymentTypes { get; set; }

        // Declare the CurrentSupplement property for supplements
        public Supplement CurrentSupplement { get; set; }

        // Command for adding a supplement
        public ICommand AddSupplementCommand { get; set; }

        // Command for saving the job
        public ICommand SaveJobCommand { get; set; }

        // Constructor to initialize the properties
        public JobsViewModel()
        {
            // Initialize the Jobs collection
            Jobs = new ObservableCollection<Job>
            {
                new Job { Name = "Developer", EmploymentType = "Full-time", PayRate = 150 },
                new Job { Name = "Designer", EmploymentType = "Part-time", PayRate = 120 }
            };

            // Initialize the CurrentJob property
            CurrentJob = new Job();

            // Initialize the EmploymentTypes list
            EmploymentTypes = new ObservableCollection<string> { "Full-time", "Part-time", "Hourly" };

            // Initialize the CurrentSupplement property
            CurrentSupplement = new Supplement();

            // Initialize the commands
            AddSupplementCommand = new Command(OnAddSupplement);
            SaveJobCommand = new Command(OnSaveJob);
        }

        // Method to handle adding a supplement
        private void OnAddSupplement()
        {
            // Your logic to add a supplement
        }

        // Method to handle saving the job
        private void OnSaveJob()
        {
            // Your logic to save the job
        }
    }
}