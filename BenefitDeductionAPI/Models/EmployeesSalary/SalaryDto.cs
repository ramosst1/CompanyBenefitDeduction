using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenefitDeductionAPI.Models.EmployeesSalary
{
    public class SalaryDto
    {

        public int EmployeeId { get; set; }
        public int NumberOfPayPeriod { get; set; }
        public double GrossSalaryAnnual { get; set; }
        public bool IsManager { get; set; } = false;
        public bool IsExemptEmployee { get; set; } = false;
        public virtual double GrossSalaryPerPayPeriod { get; set; }

    }
}
