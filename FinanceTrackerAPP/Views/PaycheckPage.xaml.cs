using FinanceTracker.ViewModels;
using System.ComponentModel;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace FinanceTracker.Views
{
    public partial class PayCheckPage : ContentPage
    {
        public PayCheckPage(PaycheckViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}