using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenefitDeductionAPI.Models.EmployeeBenefitDeduction
{
    public class BenefitDeductionItemDto
    {

        public int EmployeeId { get; set; }
        public int FamilyMemberId { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; } = "";
        public string LastName { get; set; }

        public bool IsEmployee { get; set; } = false;
        public bool IsSpouse { get; set; } = false;
        public bool IsChild { get; set; } = false;

        public int NumberOfPayPeriod { get; set; }

        public int AnnualDiscountPerentage { get; set; } = 0;
        private decimal AnnualDiscountPrice { get; set; }

        public decimal AnnualCostGross { get; set; } = 0;
        public decimal AnnualCostNet { get; set; }

        public decimal PerPayPeriodCostGross { get; set; }
        public decimal PerPayPeriodCostNet { get; set; }

    }
}
