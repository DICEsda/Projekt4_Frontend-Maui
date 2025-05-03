using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FinanceTracker.DTO;
using FinanceTracker.Services;
using Plugin.Maui.Calendar.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FinanceTracker.ViewModels
{
    public partial class LogHoursViewModel : ObservableObject
    {
        private readonly IWorkshiftService _workshiftService;
        public ObservableCollection<WorkshiftDTO> Workshifts { get; set; }


        public EventCollection Events { get; } = new EventCollection();


        public LogHoursViewModel(IWorkshiftService workshiftService)
        {
            _workshiftService = workshiftService;
        }

        public async Task InitializeCalendar()
        {


            var workshifts = await _workshiftService.GetAllWorkShifts();
            foreach (var workshift in workshifts)
            {
                var date = workshift.StartTime.Date;

                Events[date] = new List<string> { workshift.StartTime.ToString("HH:mm") + "-" + workshift.EndTime.ToString("HH:mm") };
            }
        }

        [ObservableProperty]
        private DateTime? selectedDate;


        [ObservableProperty]
        private TimeSpan startTime;

        [ObservableProperty]
        private TimeSpan endTime;


        [RelayCommand]
        public async Task AddWorkshift()
        {
            if (selectedDate == null) return;

            WorkshiftDTO workshift = new WorkshiftDTO
            {
                StartTime = selectedDate.Value.Date + startTime,
                EndTime = selectedDate.Value.Date + endTime
            };

            var result = await _workshiftService.AddWorkShift(workshift);

            if (result == null) return;

            var date = selectedDate.Value.Date;
            Events[date] = new List<string> { workshift.StartTime.ToString("HH:mm") + "-" + workshift.EndTime.ToString("HH:mm") };

        }

    }
}
