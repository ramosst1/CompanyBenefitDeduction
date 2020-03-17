using BenefitDeduction.Employees;
using BenefitDeduction.Employees.FamilyMembers;
using System;
using System.Collections.Generic;
using System.Text;

namespace BenefitDeduction.EmployeeBenefitDeduction.Employees.Calculators
{
    internal interface IDiscountCalculatorRepository
    {
        int CalculateDiscount(IEmployee employee);
        int CalculateDiscount(IFamilyMember familyMember);

    }
}
