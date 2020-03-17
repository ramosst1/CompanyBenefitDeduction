using BenefitDeduction.Employees;
using BenefitDeduction.Employees.FamilyMembers;
using System;
using System.Collections.Generic;
using System.Text;

namespace BenefitDeduction.EmployeeBenefitDeduction.Employees.Calculators
{
    internal abstract class DiscountCalculatorRepository: IDiscountCalculatorRepository
    {
        public virtual int CalculateDiscount(IEmployee employee) {

            if (employee.FirstName.StartsWith("A", StringComparison.CurrentCultureIgnoreCase)) {
                return 10;
            }
            return 0;
        }
        public virtual int CalculateDiscount(IFamilyMember familyMember)
        {

            if (familyMember.FirstName.StartsWith("A", StringComparison.CurrentCultureIgnoreCase))
            {
                return 10;
            }
            return 0;
        }
    }
}
