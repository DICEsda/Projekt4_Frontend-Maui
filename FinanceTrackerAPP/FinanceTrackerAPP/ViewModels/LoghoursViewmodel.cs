
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace FinanceTrackerAPP.ViewModels
{
    public class LogHoursViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private DateTime _newEntryDate = DateTime.Today;
        private TimeSpan _newEntryStartTime = new TimeSpan(16, 0, 0);
        private TimeSpan _newEntryEndTime = new TimeSpan(22, 0, 0);
        private int _newEntryBreakMinutes = 15;
        private string _calculatedTime;

        public ObservableCollection<Job> Jobs { get; } = new ObservableCollection<Job>();
        public ObservableCollection<LoggedHour> LoggedHours { get; } = new ObservableCollection<LoggedHour>();

        public LogHoursViewModel()
        {
            // Initialize with sample data
            DateRange = "Mar 21 - Apr 20, 2025";

            Jobs.Add(new Job { Id = 1, Name = "Job 1" });
            Jobs.Add(new Job { Id = 2, Name = "Job 2" });

            LoggedHours.Add(new LoggedHour
            {
                Date = new DateTime(2025, 3, 21),
                StartTime = new TimeSpan(16, 0, 0),
                EndTime = new TimeSpan(22, 0, 0),
                JobName = "Job 1"
            });

            // Add commands
            SaveCommand = new Command(OnSave);

            // Calculate initial time
            CalculateTime();
        }

        public string DateRange { get; private set; }

        public DateTime NewEntryDate
        {
            get => _newEntryDate;
            set
            {
                if (_newEntryDate != value)
                {
                    _newEntryDate = value;
                    OnPropertyChanged();
                }
            }
        }

        // Other properties and methods...

        public ICommand SaveCommand { get; }

        private void OnSave()
        {
            // Save logic here
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Job
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class LoggedHour
    {
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string JobName { get; set; }

        public string TimeRange => $"{StartTime:hh\\:mm} - {EndTime:hh\\:mm}";
    }
}
