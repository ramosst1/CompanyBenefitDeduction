using BenefitDeduction.Employees;
using BenefitDeduction.Employees.FamilyMembers;
using BenefitDeduction.EmployeesSalary;
using System.Collections.Generic;

namespace BenefitDeduction.EmployeeBenefitDeduction.Employees.Calculators
{
    public interface ICalculateDeductionItemsRespository
    {
        List<IBenefitDeductionItem> CalculateItems(
            IEmployee employee, 
            List<IFamilyMember> familyMembers,
            ISalary salary

        );
    }
}