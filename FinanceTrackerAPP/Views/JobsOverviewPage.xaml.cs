using FinanceTracker.ViewModels;
namespace FinanceTracker.Views
{
    public partial class JobsOverviewPage : ContentPage
    {
        public readonly JobsOverviewViewModel _viewModel;

        public JobsOverviewPage(JobsOverviewViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindingContext = _viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.LoadJobsCommand.ExecuteAsync(null);
        }
    }
}