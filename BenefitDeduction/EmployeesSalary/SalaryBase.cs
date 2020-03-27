using System;
using System.Collections.Generic;
using System.Text;

namespace BenefitDeduction.EmployeesSalary
{
    public class SalaryBase : ISalary
    {
        public int EmployeeId { get; internal set; }
        public int NumberOfPayPeriod { get; internal set; }
        public decimal GrossSalaryAnnual { get; internal set; }
        public bool IsManager { get; internal set; } = false;
        public bool IsExemptEmployee { get; internal set; } = false;
        public virtual decimal GrossSalaryPerPayPeriod {
            get {

                var Total = (GrossSalaryAnnual / NumberOfPayPeriod);
                return Math.Round(Total, 2);

            }
        }

    }
}
