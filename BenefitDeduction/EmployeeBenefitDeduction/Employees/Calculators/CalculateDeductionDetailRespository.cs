using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BenefitDeduction.EmployeesSalary;

namespace BenefitDeduction.EmployeeBenefitDeduction.Employees.Calculators
{
    internal class CalculateDeductionDetailRespository : ICalculateDeductionDetailRespository
    {
        List<IBenefitDeductionItem> _BenefitDeductionItems;
        ISalary _Salary;
        public CalculateDeductionDetailRespository(ISalary salary, List<IBenefitDeductionItem> benefitDeductionItem)
        {
            _Salary = salary;
            _BenefitDeductionItems = benefitDeductionItem;
        }

        public IBenefitDeductionDetail CalculateDeductionDetail() {

            var ABenefitDeductionDetail = new BenefitDeductionDetail() {
                AnnualTotalCostGross = CalculateAnnualTotalCostGross(),
                AnnualTotalCostNet = CalculateAnnualTotalCostNet(),
                PerPayPeriodTotalCostGross = CalculatePerPayPeriodTotalCostGross(),
                PerPayPeriodTotalCostNet = CalculatePerPayPeriodTotalCostNet(),
                BenefitDeductionItems = _BenefitDeductionItems,
                EmployeeSalary = _Salary.GrossSalaryAnnual,
                EmployeeSalaryPerPayPeriod = _Salary.GrossSalaryPerPayPeriod
            };

            ABenefitDeductionDetail.AnnualSalaryAjustment = 
                CalculateAnnualSalaryAjustment(ABenefitDeductionDetail);

            ABenefitDeductionDetail.PerPayPeriodSalaryAjustment = 
                CalculatePerPayPeriodSalaryAjustment(ABenefitDeductionDetail);

            ABenefitDeductionDetail.PerPayPeriodBenefitAjustment =
                CalculatePerPayPeriodBenefitAjustment(ABenefitDeductionDetail);

            return ABenefitDeductionDetail;
        }

        private decimal CalculateAnnualTotalCostGross() {
            var Total = _BenefitDeductionItems.Select(aItem => aItem.AnnualCostGross).Sum() + .00m;
            return Math.Round(Total, 2);
        }

        private decimal CalculateAnnualTotalCostNet() {
            var Total = _BenefitDeductionItems.Select(aItem => aItem.AnnualCostNet).Sum() +.00m;
            return Math.Round(Total, 2);
        }

        private decimal CalculatePerPayPeriodTotalCostGross() {
            var Total = _BenefitDeductionItems.Select(aItem => aItem.PerPayPeriodCostGross).Sum() + .00m;
            return Math.Round(Total, 2);
        }

        private decimal CalculatePerPayPeriodTotalCostNet() {
            var Total = _BenefitDeductionItems.Select(aItem => aItem.PerPayPeriodCostNet).Sum() +.00m;
            return Math.Round(Total, 2);
        }

        private decimal CalculateAnnualSalaryAjustment(BenefitDeductionDetail benefitDeductionDetail) {

            var Total = (_Salary.GrossSalaryAnnual - benefitDeductionDetail.AnnualTotalCostNet) + .00m;
            return Math.Round(Total, 2);

        }
        private decimal CalculatePerPayPeriodSalaryAjustment(BenefitDeductionDetail benefitDeductionDetail)
        {

            var Total = (_Salary.GrossSalaryPerPayPeriod - benefitDeductionDetail.PerPayPeriodTotalCostNet) + .00m;
            return Math.Round(Total, 2, MidpointRounding.AwayFromZero);

        }

        private decimal CalculatePerPayPeriodBenefitAjustment(BenefitDeductionDetail benefitDeductionDetail)
        {

            if (benefitDeductionDetail.PerPayPeriodTotalCostGross == benefitDeductionDetail.PerPayPeriodTotalCostNet) {

                return benefitDeductionDetail.PerPayPeriodTotalCostGross;
            }

            return benefitDeductionDetail.PerPayPeriodTotalCostNet;

            //(${
            //    this.state.perPayPeriodTotalCostGross === this.state.perPayPeriodTotalCostNet ? this.state.perPayPeriodTotalCostGross :
            //     this.state.perPayPeriodTotalCostNet
                                                //})

        }

    }
}
