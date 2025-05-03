using System;

namespace FinanceTracker.Models
{
    public class JobDTO
    {
        public string Title { get; set; }
        public string TaxCard { get; set; }
        public decimal HourlyRate { get; set; }
        public string EmploymentType { get; set; }
        public string CompanyName { get; set; }

    }
}