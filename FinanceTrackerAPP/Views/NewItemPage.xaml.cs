using FinanceTracker.Models;
using FinanceTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace FinanceTracker.Views
{
    public partial class NewItemPage : ContentPage
    {
        public NewItemPage(NewItemViewModel viewModel)
        {
            InitializeComponent();
            if(viewModel == null ) { throw new ArgumentNullException(nameof(viewModel)); }
            BindingContext = viewModel;
        }
    }
}