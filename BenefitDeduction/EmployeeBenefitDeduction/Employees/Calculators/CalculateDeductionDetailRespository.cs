using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BenefitDeduction.EmployeeBenefitDeduction.Employees.Calculators
{
    internal class CalculateDeductionDetailRespository : ICalculateDeductionDetailRespository
    {
        List<IBenefitDeductionItem> _BenefitDeductionItems;
        public CalculateDeductionDetailRespository(List<IBenefitDeductionItem> benefitDeductionItem)
        {
            _BenefitDeductionItems = benefitDeductionItem;
        }

        public IBenefitDeductionDetail CalculateDeductionDetail() {

            var ABenefitDeductionDetail = new BenefitDeductionDetail() {
                AnnualTotalCostGross = CalculateAnnualTotalCostGross(),
                AnnualTotalCostNet = CalculateAnnualTotalCostNet(),
                PerPayPeriodTotalCostGross = CalculatePerPayPeriodTotalCostGross(),
                PerPayPeriodTotalCostNet = CalculatePerPayPeriodTotalCostNet(),
                BenefitDeductionItems = _BenefitDeductionItems,
            };

            return ABenefitDeductionDetail;
        }

        private decimal CalculateAnnualTotalCostGross() {
            var Total = _BenefitDeductionItems.Select(aItem => aItem.AnnualCostGross).Sum();
            return Math.Round(Total, 2, MidpointRounding.AwayFromZero);
        }

        private decimal CalculateAnnualTotalCostNet() {
            var Total = _BenefitDeductionItems.Select(aItem => aItem.AnnualCostNet).Sum();
            return Math.Round(Total, 2, MidpointRounding.AwayFromZero);
        }

        private decimal CalculatePerPayPeriodTotalCostGross() {
            var Total = _BenefitDeductionItems.Select(aItem => aItem.PerPayPeriodCostGross).Sum();
            return Math.Round(Total, 2, MidpointRounding.AwayFromZero);
        }

        private decimal CalculatePerPayPeriodTotalCostNet() {
            var Total = _BenefitDeductionItems.Select(aItem => aItem.PerPayPeriodCostNet).Sum();
            return Math.Round(Total, 2, MidpointRounding.AwayFromZero);
        }

    }
}
