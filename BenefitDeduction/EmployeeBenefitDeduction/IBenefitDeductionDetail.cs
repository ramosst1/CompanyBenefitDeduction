using System;
using System.Collections.Generic;
using System.Text;

namespace BenefitDeduction.EmployeeBenefitDeduction
{
    public interface IBenefitDeductionDetail
    {
        decimal AnnualTotalCostGross { get; }
        decimal AnnualTotalCostNet { get; }
        decimal PerPayPeriodTotalCostGross { get; }
        decimal PerPayPeriodTotalCostNet { get; }

        List<IBenefitDeductionItem> BenefitDeductionItems { get; }

    }
}
