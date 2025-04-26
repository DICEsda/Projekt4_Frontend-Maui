using System;
using System.Collections.ObjectModel;

namespace FinanceTracker.Models
{
    public class Item
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }

    public class Job
    {
        public string? Name { get; set; }
        public string EmploymentType { get; set; }
        public double PayRate { get; set; }
        public string? CVR { get; set; }
        public int PayPeriodStart { get; set; }
        public int PayPeriodEnd { get; set; }

        public ObservableCollection<Supplement> Supplements { get; set; } = new ObservableCollection<Supplement>();
        public bool IsACard { get; set; }
        public bool IsBCard { get; set; }
    }

    // Sample Supplement Model
    public class Supplement
    {
        public string? Name { get; set; }
        public string? Days { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public double ExtraRate { get; set; }
    }
}