using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BenefitDeduction.EmployeesSalary;

namespace BenefitDeduction.EmployeeBenefitDeduction.Employees.Calculators
{
    public class CalculateDeductionDetailRespository : ICalculateDeductionDetailRespository
    {
        public CalculateDeductionDetailRespository()
        {
        }

        public IBenefitDeductionDetail CalculateDeductionDetail(ISalary salary, List<IBenefitDeductionItem> benefitDeductionItems) {

            var ABenefitDeductionDetail = new BenefitDeductionDetail() {
                AnnualTotalCostGross = CalculateAnnualTotalCostGross(benefitDeductionItems),
                AnnualTotalCostNet = CalculateAnnualTotalCostNet(benefitDeductionItems),
                PerPayPeriodTotalCostGross = CalculatePerPayPeriodTotalCostGross(benefitDeductionItems),
                PerPayPeriodTotalCostNet = CalculatePerPayPeriodTotalCostNet(benefitDeductionItems),
                BenefitDeductionItems = benefitDeductionItems,
                EmployeeSalary = salary.GrossSalaryAnnual,
                EmployeeSalaryPerPayPeriod = salary.GrossSalaryPerPayPeriod
            };

            ABenefitDeductionDetail.AnnualSalaryAjustment = 
                CalculateAnnualSalaryAjustment(salary, ABenefitDeductionDetail);

            ABenefitDeductionDetail.PerPayPeriodSalaryAjustment = 
                CalculatePerPayPeriodSalaryAjustment(salary, ABenefitDeductionDetail);

            ABenefitDeductionDetail.PerPayPeriodBenefitAjustment =
                CalculatePerPayPeriodBenefitAjustment(ABenefitDeductionDetail);

            return ABenefitDeductionDetail;
        }

        private decimal CalculateAnnualTotalCostGross(List<IBenefitDeductionItem> benefitDeductionItems) {
            var Total = benefitDeductionItems.Select(aItem => aItem.AnnualCostGross).Sum() + .00m;
            return Math.Round(Total, 2);
        }

        private decimal CalculateAnnualTotalCostNet(List<IBenefitDeductionItem> benefitDeductionItems) {
            var Total = benefitDeductionItems.Select(aItem => aItem.AnnualCostNet).Sum() +.00m;
            return Math.Round(Total, 2);
        }

        private decimal CalculatePerPayPeriodTotalCostGross(List<IBenefitDeductionItem> benefitDeductionItems) {
            var Total = benefitDeductionItems.Select(aItem => aItem.PerPayPeriodCostGross).Sum() + .00m;
            return Math.Round(Total, 2);
        }

        private decimal CalculatePerPayPeriodTotalCostNet(List<IBenefitDeductionItem> benefitDeductionItems) {
            var Total = benefitDeductionItems.Select(aItem => aItem.PerPayPeriodCostNet).Sum() +.00m;
            return Math.Round(Total, 2);
        }

        private decimal CalculateAnnualSalaryAjustment(ISalary salary, BenefitDeductionDetail benefitDeductionDetail) {

            var Total = (salary.GrossSalaryAnnual - benefitDeductionDetail.AnnualTotalCostNet) + .00m;
            return Math.Round(Total, 2);

        }
        private decimal CalculatePerPayPeriodSalaryAjustment(ISalary salary, BenefitDeductionDetail benefitDeductionDetail)
        {

            var Total = (salary.GrossSalaryPerPayPeriod - benefitDeductionDetail.PerPayPeriodTotalCostNet) + .00m;
            return Math.Round(Total, 2, MidpointRounding.AwayFromZero);

        }

        private decimal CalculatePerPayPeriodBenefitAjustment(BenefitDeductionDetail benefitDeductionDetail)
        {

            if (benefitDeductionDetail.PerPayPeriodTotalCostGross == benefitDeductionDetail.PerPayPeriodTotalCostNet) {

                return benefitDeductionDetail.PerPayPeriodTotalCostGross;
            }

            return benefitDeductionDetail.PerPayPeriodTotalCostNet;

        }

    }
}
