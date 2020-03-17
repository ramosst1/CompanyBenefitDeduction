using BenefitDeduction.Employees;
using BenefitDeduction.EmployeesSalary.Employees;
using System;
using System.Collections.Generic;
using System.Text;

namespace BenefitDeduction.EmployeesSalary
{
    public class SalaryRepository : ISalaryRepository
    {
        IEmployee _Employee;
        public SalaryRepository(IEmployee employee)
        {
            _Employee = employee;
        }

        public ISalary GetSalary() {


            try
            {

                ISalaryRepository SalaryEmployeeRepos = null;

                if(_Employee.IsExempt == true)
                {
                    SalaryEmployeeRepos = new SalaryEmployeeExemptRepository(_Employee);
                }

                return SalaryEmployeeRepos?.GetSalary();


            }
            catch (Exception e)
            {
                throw new Exception("Some error message");
            }


        }

    }
}
