using BenefitDeduction.EmployeeBenefitDeduction.Employees.Calculators;
using BenefitDeduction.Employees;
using BenefitDeduction.Employees.FamilyMembers;
using BenefitDeduction.EmployeesSalary;
using System;
using System.Collections.Generic;
using System.Text;

namespace BenefitDeduction.EmployeeBenefitDeduction.Employees
{
    public class DeductionEmployeeRepository : IDeductionEmployeeRepository
    {

        IEmployee _Employee;
        List<IFamilyMember> _FamilyMembers;
        ISalary _Salary;

        ICalculateDeductionItemsRespository _CalculatorEmployeeRepos;
        ICalculateDeductionDetailRespository _CalculateDeductionDetailRespos;
        List <IBenefitDeductionItem> _BenefitDeductionItems;

        public DeductionEmployeeRepository(
            IEmployee employee, 
            List<IFamilyMember> familyMembers,
            ISalary salary
            
        )
        {
            _Employee = employee;
            _FamilyMembers = familyMembers;
            _Salary = salary;

            _CalculatorEmployeeRepos = new CalculateDeductionItemsRespository(_Employee, _FamilyMembers, _Salary);

            _BenefitDeductionItems = _CalculatorEmployeeRepos.CalculateItems();

            _CalculateDeductionDetailRespos = new CalculateDeductionDetailRespository(_Salary,_BenefitDeductionItems);


        }

        public IBenefitDeductionDetail CalculateBenefitDeductionDetail() {

           var ABenefitDeductiondetail = _CalculateDeductionDetailRespos.CalculateDeductionDetail();

            return ABenefitDeductiondetail;
        }


    }
}
