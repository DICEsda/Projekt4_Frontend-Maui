using System;

namespace FinanceTracker.Models
{
    public class JobDTO
    {
        public string CompanyName { get; set; }
        public decimal HourlyRate { get; set; }
        public string EmploymentType { get; set; }
        public string TaxCard { get; set; }
        public string? Title { get; set; }


    }
}