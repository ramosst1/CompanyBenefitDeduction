using System;
using System.Collections.Generic;
using System.Text;

namespace BenefitDeduction.EmployeeBenefitDeduction
{
    public class BenefitDeductionItemBase : IBenefitDeductionItem
    {

        public int EmployeeId { get; internal set; }
        public int FamilyMemberId { get; internal set; }

        public string FirstName { get; internal set; }
        public string MiddleName { get; internal set; } = "";
        public string LastName { get; internal set; }

        public bool IsEmployee { get; internal set; } = false;
        public bool IsSpouse { get; internal set; } = false;
        public bool IsChild { get; internal set; } = false;

        public int NumberOfPayPeriod { get; internal set; }

        public int AnnualDiscountPerentage { get; internal set; } = 0;
        private decimal AnnualDiscountPrice
        {
            get
            {
                return AnnualDiscountPerentage == 0? 0 :  (AnnualCostGross / AnnualDiscountPerentage) + .00m;
            }
        }
        public decimal AnnualCostGross { get; internal set; } = 0;
        public decimal AnnualCostNet
        {
            get
            {
                var Total = AnnualDiscountPerentage == 0? AnnualCostGross :(AnnualCostGross - AnnualDiscountPrice) + .00m;
                return Math.Round(Total, 2);
            }
        }
        public decimal PerPayPeriodCostGross { get {
                var Total = (AnnualCostGross / NumberOfPayPeriod) + .00m;
                return Math.Round(Total, 2);
            }
        }
        public decimal PerPayPeriodCostNet {
            get {
                var Total = (AnnualCostNet / NumberOfPayPeriod) + .00m;
                return Math.Round(Total, 2);
            }
        }

    }
}
