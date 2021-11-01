using BenefitDeduction.EmployeesSalary;
using System.Collections.Generic;

namespace BenefitDeduction.EmployeeBenefitDeduction.Employees.Calculators
{
    public interface ICalculateDeductionDetailRespository
    {
        IBenefitDeductionDetail CalculateDeductionDetail(ISalary salary, List<IBenefitDeductionItem> benefitDeductionItems);
    }
}