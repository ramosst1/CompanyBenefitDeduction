using BenefitDeduction.EmployeeBenefitDeduction.Employees;
using BenefitDeduction.Employees;
using BenefitDeduction.Employees.FamilyMembers;
using BenefitDeduction.EmployeesSalary;
using System.Collections.Generic;

namespace BenefitDeduction.EmployeeBenefitDeduction
{
    public class BenefitDeductionRepository : IBenefitDeductionRepository
    {

        IEmployee _Employee;
        List<IFamilyMember> _FamilyMembers;
        ISalary _Salary;

        public BenefitDeductionRepository(
            IEmployee employee, 
            List<IFamilyMember> familyMembers,
            ISalary salary
            
        )
        {
            _Employee = employee;
            _FamilyMembers = familyMembers;
            _Salary = salary;

        }

        public IBenefitDeductionDetail CalculateBenefitDeductionDetail() {


            IBenefitDeductionRepository ABenefitDeductionRepos = null;

            if (_Employee.IsExempt) {
                ABenefitDeductionRepos = new DeductionEmployeeRepository(_Employee, _FamilyMembers, _Salary);
            }

            var ABenefitDeductionDetail = ABenefitDeductionRepos?.CalculateBenefitDeductionDetail();

            return ABenefitDeductionDetail;
        }


    }
}
