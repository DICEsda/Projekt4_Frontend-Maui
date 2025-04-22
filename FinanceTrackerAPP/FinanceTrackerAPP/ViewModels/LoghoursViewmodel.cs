using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace FinanceTrackerAPP.ViewModels
{
    public class LogHoursViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private DateTime _newEntryDate = DateTime.Today;
        private TimeSpan _newEntryStartTime = new TimeSpan(16, 0, 0);
        private TimeSpan _newEntryEndTime = new TimeSpan(22, 0, 0);
        private int _newEntryBreakMinutes = 15;
        private string _calculatedTime = string.Empty;

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

        public string DateRange { get; private set; } = string.Empty;

        public DateTime NewEntryDate
        {
            get => _newEntryDate;
            set
            {
                if (_newEntryDate != value)
                {
                    _newEntryDate = value;
                    OnPropertyChanged();
                    CalculateTime();
                }
            }
        }

        public TimeSpan NewEntryStartTime
        {
            get => _newEntryStartTime;
            set
            {
                if (_newEntryStartTime != value)
                {
                    _newEntryStartTime = value;
                    OnPropertyChanged();
                    CalculateTime();
                }
            }
        }

        public TimeSpan NewEntryEndTime
        {
            get => _newEntryEndTime;
            set
            {
                if (_newEntryEndTime != value)
                {
                    _newEntryEndTime = value;
                    OnPropertyChanged();
                    CalculateTime();
                }
            }
        }

        public int NewEntryBreakMinutes
        {
            get => _newEntryBreakMinutes;
            set
            {
                if (_newEntryBreakMinutes != value)
                {
                    _newEntryBreakMinutes = value;
                    OnPropertyChanged();
                    CalculateTime();
                }
            }
        }

        public string CalculatedTime
        {
            get => _calculatedTime;
            private set
            {
                if (_calculatedTime != value)
                {
                    _calculatedTime = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand SaveCommand { get; }

        private void CalculateTime()
        {
            // Calculate the time difference
            TimeSpan duration = _newEntryEndTime - _newEntryStartTime;
            
            // Subtract break minutes
            if (duration.TotalMinutes > 0 && _newEntryBreakMinutes > 0)
            {
                duration = duration.Subtract(TimeSpan.FromMinutes(_newEntryBreakMinutes));
            }
            
            // Format as hours and minutes
            CalculatedTime = $"{Math.Floor(duration.TotalHours)}h {duration.Minutes}m";
        }

        private void OnSave()
        {
            // Save logic here
            LoggedHours.Add(new LoggedHour
            {
                Date = NewEntryDate,
                StartTime = NewEntryStartTime,
                EndTime = NewEntryEndTime,
                JobName = "Job 1" // Should use selected job
            });
        }

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Job
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }

    public class LoggedHour
    {
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public required string JobName { get; set; }

        public string TimeRange => $"{StartTime:hh\\:mm} - {EndTime:hh\\:mm}";
    }
}
