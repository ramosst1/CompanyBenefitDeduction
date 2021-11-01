using BenefitDeduction.EmployeeBenefitDeduction.Employees.Calculators;
using BenefitDeduction.Employees;
using BenefitDeduction.Employees.FamilyMembers;
using BenefitDeduction.EmployeesSalary;
using System.Collections.Generic;

namespace BenefitDeduction.EmployeeBenefitDeduction.Employees
{
    public class DeductionEmployeeRepository : IDeductionEmployeeRepository
    {

        ICalculateDeductionItemsRespository _CalculateDeductionItemsRespos;
        ICalculateDeductionDetailRespository _CalculateDeductionDetailRespos;

        List <IBenefitDeductionItem> _BenefitDeductionItems;

        public DeductionEmployeeRepository(
            ICalculateDeductionItemsRespository calculateDeductionItemsRespos, 
            ICalculateDeductionDetailRespository calculateDeductionDetailRespos
        )
        {
            _CalculateDeductionItemsRespos = calculateDeductionItemsRespos;
            _CalculateDeductionDetailRespos = calculateDeductionDetailRespos;
        }

        public IBenefitDeductionDetail CalculateBenefitDeductionDetail(            
            IEmployee employee, 
            List<IFamilyMember> familyMembers,
            ISalary salary
        ) {

            _BenefitDeductionItems = _CalculateDeductionItemsRespos.CalculateItems(employee, familyMembers, salary);

           var ABenefitDeductiondetail = _CalculateDeductionDetailRespos.CalculateDeductionDetail(salary,_BenefitDeductionItems);

            return ABenefitDeductiondetail;
        }


    }
}
