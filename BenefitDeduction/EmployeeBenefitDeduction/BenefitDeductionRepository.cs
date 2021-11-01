using BenefitDeduction.EmployeeBenefitDeduction.Employees;
using BenefitDeduction.Employees;
using BenefitDeduction.Employees.FamilyMembers;
using BenefitDeduction.EmployeesSalary;
using System.Collections.Generic;

namespace BenefitDeduction.EmployeeBenefitDeduction
{
    public class BenefitDeductionRepository : IBenefitDeductionRepository
    {

        private IDeductionEmployeeRepository _DeductionEmployeeRepos;
        public BenefitDeductionRepository(IDeductionEmployeeRepository deductionEmployeeRepos)
        {
            _DeductionEmployeeRepos = deductionEmployeeRepos;
        }

        public IBenefitDeductionDetail CalculateBenefitDeductionDetail(
            IEmployee employee, 
            List<IFamilyMember> familyMembers,
            ISalary salary

        ) {

            IBenefitDeductionDetail ABenefitDeductionDetail = null; 

            if(employee.IsExempt) {
                ABenefitDeductionDetail = _DeductionEmployeeRepos.CalculateBenefitDeductionDetail(employee, familyMembers, salary);
            }

            return ABenefitDeductionDetail;
        }


    }
}
