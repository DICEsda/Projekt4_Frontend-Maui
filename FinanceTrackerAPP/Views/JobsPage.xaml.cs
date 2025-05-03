using System.Diagnostics;
using FinanceTracker.Models;
using FinanceTracker.ViewModels;
using FinanceTracker.Views;

namespace FinanceTracker.Views
{

    public partial class JobsPage : ContentPage
    {

        public JobsPage(JobsViewModel jobsViewModel)
        {
            InitializeComponent();
            BindingContext = jobsViewModel;
        }


    }
}