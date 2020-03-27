using BenefitDeduction.Employees;
using BenefitDeduction.Employees.FamilyMembers;
using BenefitDeduction.EmployeesSalary;
using System;
using System.Collections.Generic;
using System.Text;

namespace BenefitDeduction.EmployeeBenefitDeduction.Employees.Calculators
{
    internal class CalculateDeductionItemsRespository : DiscountCalculatorRepository, ICalculateDeductionItemsRespository
    {
        IEmployee _Employee;
        List <IFamilyMember> _FamilyMembers;
        ISalary _Salary;
        public CalculateDeductionItemsRespository(
            IEmployee employee, 
            List<IFamilyMember> familyMembers,
            ISalary salary
            )
        {
            _Employee = employee;
            _FamilyMembers = familyMembers;
            _Salary = salary;
        }

        public List<IBenefitDeductionItem> CalculateItems() {

            var BenefitDeductItems = new List<IBenefitDeductionItem>();

            BenefitDeductItems.Add(CreateBenefitItem(_Employee));
            BenefitDeductItems.AddRange(CreateBenefitItem(_FamilyMembers));

            return BenefitDeductItems;
        }

        private IBenefitDeductionItem CreateBenefitItem(IEmployee employee) {

            return new BenefitDeductionItem()
            {
                NumberOfPayPeriod = _Salary.NumberOfPayPeriod,
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

        private List <IBenefitDeductionItem> CreateBenefitItem(List <IFamilyMember> familyMembers)
        {
            List<IBenefitDeductionItem> DeductionItems = new List<IBenefitDeductionItem>();

            familyMembers.ForEach(delegate(IFamilyMember aFamilyMember)  {
                DeductionItems.Add(CreateBenefitItem(aFamilyMember));
            });

            return DeductionItems;
        }

        private IBenefitDeductionItem CreateBenefitItem(IFamilyMember familyMember)
        {

            return new BenefitDeductionItem()
            {
                EmployeeId = _Employee.EmployeeId,
                FamilyMemberId = familyMember.FamilyMemberId,
                FirstName = familyMember.FirstName,
                MiddleName = familyMember.MiddleName,
                LastName = familyMember.LastName,
                NumberOfPayPeriod = _Salary.NumberOfPayPeriod,
                AnnualCostGross = 500.00m,
                IsSpouse = familyMember.IsSpouse,
                IsChild = familyMember.IsChild,
                AnnualDiscountPerentage = CalculateDiscount(familyMember)
            };
        }

    }
}
