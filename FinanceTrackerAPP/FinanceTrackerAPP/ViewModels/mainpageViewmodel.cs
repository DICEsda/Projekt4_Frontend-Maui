using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FinanceTrackerAPP.Views;

namespace FinanceTrackerAPP.ViewModels
{
    public class MainPageViewModel
    {
        public ICommand JobOverviewCommand { get; }
        public ICommand LogHoursCommand { get; }
        public ICommand PaycheckCommand { get; }
        public ICommand HolidayPayCommand { get; }
        public ICommand StudentGrantCommand { get; }

        public MainPageViewModel()
        {
            JobOverviewCommand = new Command(async () => await Shell.Current.GoToAsync(nameof(Add_Edit)));
            LogHoursCommand = new Command(async () => await Shell.Current.GoToAsync(nameof(Loghours)));
            PaycheckCommand = new Command(() => { /* To be implemented */ });
            HolidayPayCommand = new Command(() => { /* To be implemented */ });
            StudentGrantCommand = new Command(() => { /* To be implemented */ });
        }
    }
}
