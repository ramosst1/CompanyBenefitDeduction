using BenefitDeduction.Employees;
using BenefitDeduction.EmployeesSalary.Employees;
using System;
using System.Collections.Generic;
using System.Text;

namespace BenefitDeduction.EmployeesSalary
{
    public class SalaryRepository : ISalaryRepository
    {
        public SalaryRepository()
        {
        }

        public ISalary GetSalary(IEmployee employee) {


            try
            {

                ISalaryRepository SalaryEmployeeRepos = null;

                if(employee.IsExempt == true)
                {
                    SalaryEmployeeRepos = new SalaryEmployeeExemptRepository(employee);
//                    SalaryEmployeeRepos = new SalaryEmployeeExemptRepository();
                }

                return SalaryEmployeeRepos?.GetSalary(employee);


            }
            catch (Exception e)
            {
                throw new Exception("Some error message");
            }


        }

    }
}
