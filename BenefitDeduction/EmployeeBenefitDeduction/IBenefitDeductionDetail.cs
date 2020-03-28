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
        decimal PerPayPeriodTotalCostGrossGrandTotal { get; }

        decimal PerPayPeriodTotalCostNet { get; }
        decimal PerPayPeriodTotalCostNetGrandTotal { get; }
        decimal PerPayPeriodSalaryAjustment { get; }

        decimal EmployeeSalary { get; }

        List<IBenefitDeductionItem> BenefitDeductionItems { get; }

    }
}
