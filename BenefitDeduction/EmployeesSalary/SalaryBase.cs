using System;
using System.Collections.Generic;
using System.Text;

namespace BenefitDeduction.EmployeesSalary
{
    public class SalaryBase : ISalary
    {
        public int EmployeeId { get; internal set; }
        public int NumberOfPayPeriod { get; internal set; }
        public double GrossSalaryAnnual { get; internal set; }
        public bool IsManager { get; internal set; } = false;
        public bool IsExemptEmployee { get; internal set; } = false;
        public virtual double GrossSalaryPerPayPeriod {
            get {
                return GrossSalaryAnnual / NumberOfPayPeriod;
            }
        }

    }
}
