using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.DTO
{
    public class PayCheckDTO
    {
        public decimal SalaryBeforeTax { get; set; }
        public decimal AMContribution { get; set; }
        public decimal Tax { get; set; }
        public decimal SalaryAfterTax { get; set; }
        public double WorkedHours { get; set; }

    }
}
