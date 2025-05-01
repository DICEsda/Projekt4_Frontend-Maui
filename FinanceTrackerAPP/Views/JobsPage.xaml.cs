using System.Diagnostics;
using FinanceTracker.Models;
using FinanceTracker.ViewModels;
using FinanceTracker.Views;

namespace FinanceTracker.Views
{

    public partial class JobsPage : ContentPage
    {
        private readonly JobsViewModel JobsViewModel;
        public JobsPage()
        {
            InitializeComponent();
            BindingContext = JobsViewModel;
        }


    }
}