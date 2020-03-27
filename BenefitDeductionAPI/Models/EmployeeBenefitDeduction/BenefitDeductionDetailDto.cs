using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenefitDeductionAPI.Models.EmployeeBenefitDeduction
{
    public class BenefitDeductionDetailDto
    {

        public decimal AnnualTotalCostGross { get; set; }
        public decimal AnnualTotalCostNet { get; set; }
        public decimal AnnualSalaryAjustment { get; set; }

        public decimal PerPayPeriodTotalCostGross { get; set; }
        public decimal PerPayPeriodTotalCostNet { get; set; }
        public decimal PerPayPeriodSalaryAjustment { get; set; }

        public decimal EmployeeSalary { get; set; }

        public List<BenefitDeductionItemDto> BenefitDeductionItems { get; set; }
            = new List<BenefitDeductionItemDto>();



    }
}
