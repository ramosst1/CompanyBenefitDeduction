using BenefitDeduction.Employees;
using BenefitDeduction.Employees.FamilyMembers;
using BenefitDeduction.EmployeesSalary;
using System;
using System.Collections.Generic;
using System.Text;

namespace BenefitDeduction.EmployeeBenefitDeduction.Employees.Calculators
{
    public class CalculateDeductionItemsRespository : DiscountCalculatorRepository, ICalculateDeductionItemsRespository
    {

        public CalculateDeductionItemsRespository()
        {
            
        }
        public List<IBenefitDeductionItem> CalculateItems(
            IEmployee employee, 
            List<IFamilyMember> familyMembers,
            ISalary salary
        ) {

            var BenefitDeductItems = new List<IBenefitDeductionItem>();

            BenefitDeductItems.Add(CreateBenefitItem(employee,salary));
            BenefitDeductItems.AddRange(CreateBenefitItem(employee,familyMembers, salary));

            return BenefitDeductItems;
        }

        private IBenefitDeductionItem CreateBenefitItem(IEmployee employee, ISalary salary) {

            return new BenefitDeductionItem()
            {
                NumberOfPayPeriod = salary.NumberOfPayPeriod,
                EmployeeId = employee.EmployeeId,
                FamilyMemberId = employee.EmployeeId,
                FirstName = employee.FirstName,
                MiddleName = employee.MiddleName,
                IsEmployee = true,
                LastName = employee.LastName,
                AnnualCostGross = 1000.00m,
                AnnualDiscountPerentage = CalculateDiscount(employee)
            };
        }

        private List <IBenefitDeductionItem> CreateBenefitItem(
            IEmployee employee, 
            List <IFamilyMember> familyMembers,
            ISalary salary
        )
            
        {
            List<IBenefitDeductionItem> DeductionItems = new List<IBenefitDeductionItem>();

            familyMembers.ForEach(delegate(IFamilyMember aFamilyMember)  {
                DeductionItems.Add(CreateBenefitItem(employee, aFamilyMember,salary));
            });

            return DeductionItems;
        }

        private IBenefitDeductionItem CreateBenefitItem(
            IEmployee employee, 
            IFamilyMember familyMember,
            ISalary salary
        )
        {

            return new BenefitDeductionItem()
            {
                EmployeeId = employee.EmployeeId,
                FamilyMemberId = familyMember.FamilyMemberId,
                FirstName = familyMember.FirstName,
                MiddleName = familyMember.MiddleName,
                LastName = familyMember.LastName,
                NumberOfPayPeriod = salary.NumberOfPayPeriod,
                AnnualCostGross = 500.00m,
                IsSpouse = familyMember.IsSpouse,
                IsChild = familyMember.IsChild,
                AnnualDiscountPerentage = CalculateDiscount(familyMember)
            };
        }

    }
}
