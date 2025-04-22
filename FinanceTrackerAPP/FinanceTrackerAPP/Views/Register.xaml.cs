using FinanceTrackerAPP.ViewModels;

namespace FinanceTrackerAPP.Views;
    public partial class Register : ContentPage
    {

        public Register()
        {
            InitializeComponent();
            BindingContext = new registerViewmodel();
    }

    }
