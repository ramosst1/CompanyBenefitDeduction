using BenefitDeduction.Employees;
using BenefitDeduction.EmployeesSalary.Employees;
using System;

namespace BenefitDeduction.EmployeesSalary
{
    public class SalaryRepository : ISalaryRepository
    {
        private ISalaryEmployeeExemptRepository _SalaryEmployeeExemptRepos;  
        public SalaryRepository(ISalaryEmployeeExemptRepository salaryEmployeeExemptRepos)
        {
            _SalaryEmployeeExemptRepos = salaryEmployeeExemptRepos;
        }

        public ISalary GetSalary(IEmployee employee) {

            try
            {

                if(employee.IsExempt == true)
                {
                    return _SalaryEmployeeExemptRepos.GetSalary(employee);
                }

                return null;

            }
            catch (Exception e)
            {
                throw new Exception("Some error message");
            }

        }

    }
}
