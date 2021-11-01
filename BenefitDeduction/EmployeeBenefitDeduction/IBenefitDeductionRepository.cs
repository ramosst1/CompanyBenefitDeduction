using BenefitDeduction.Employees;
using BenefitDeduction.Employees.FamilyMembers;
using BenefitDeduction.EmployeesSalary;
using System.Collections.Generic;

namespace BenefitDeduction.EmployeeBenefitDeduction
{
    public interface IBenefitDeductionRepository
    {
        IBenefitDeductionDetail CalculateBenefitDeductionDetail(
            IEmployee employee, 
            List<IFamilyMember> familyMembers,
            ISalary salary

        );
    }
}