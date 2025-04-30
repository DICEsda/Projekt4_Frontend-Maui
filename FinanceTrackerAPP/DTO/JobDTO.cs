using System;

namespace FinanceTracker.Models
{
    public class JobDTO
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal PayRate { get; set; }
        public string EmploymentType { get; set; }

    }
}