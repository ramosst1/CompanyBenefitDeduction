using System;
using System.Collections.Generic;
using System.Text;

namespace BenefitDeduction.EmployeeBenefitDeduction
{
    public abstract class BenefitDeductionDetailBase : IBenefitDeductionDetail
    {

        public decimal AnnualTotalCostGross { get; internal set; }
        public decimal AnnualTotalCostNet { get; internal set; }
        public decimal AnnualSalaryAjustment { get; internal set; }

        public decimal PerPayPeriodTotalCostGross { get; internal set; }
        public decimal PerPayPeriodTotalCostNet { get; internal set; }
        public decimal PerPayPeriodSalaryAjustment { get; internal set; }

        public decimal PerPayPeriodBenefitAjustment { get; internal set;  }

        public List<IBenefitDeductionItem> BenefitDeductionItems { get; internal set; } 
            = new List<IBenefitDeductionItem>();
        public decimal EmployeeSalary { get; internal set; }
        public decimal EmployeeSalaryPerPayPeriod { get; internal set; }
    }
}
