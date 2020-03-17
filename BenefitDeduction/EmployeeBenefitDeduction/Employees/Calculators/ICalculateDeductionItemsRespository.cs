using System.Collections.Generic;

namespace BenefitDeduction.EmployeeBenefitDeduction.Employees.Calculators
{
    public interface ICalculateDeductionItemsRespository
    {
        List<IBenefitDeductionItem> CalculateItems();
    }
}