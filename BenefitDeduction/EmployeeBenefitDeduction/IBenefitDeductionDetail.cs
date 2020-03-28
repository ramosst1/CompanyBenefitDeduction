using System;
using System.Collections.Generic;
using System.Text;

namespace BenefitDeduction.EmployeeBenefitDeduction
{
    public interface IBenefitDeductionDetail
    {
        decimal AnnualTotalCostGross { get; }
        decimal AnnualTotalCostNet { get; }
        decimal AnnualSalaryAjustment { get; }

        decimal PerPayPeriodTotalCostGross { get; }

        decimal PerPayPeriodTotalCostNet { get; }
        decimal PerPayPeriodSalaryAjustment { get; }

        decimal EmployeeSalary { get; }
        decimal EmployeeSalaryPerPayPeriod { get; }

        decimal PerPayPeriodBenefitAjustment { get; }

        List<IBenefitDeductionItem> BenefitDeductionItems { get; }

    }
}
