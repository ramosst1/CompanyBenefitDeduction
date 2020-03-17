using BenefitDeduction.Employees;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BenefitDeduction.EmployeesSalary.Employees
{
    public class SalaryEmployeeExemptRepository : ISalaryEmployeeExemptRepository
    {
        IEmployee _Employee;
        public SalaryEmployeeExemptRepository(IEmployee employee)
        {
            _Employee = employee;
        }

        public ISalary GetSalary()
        {
            try
            {
                return GetSalaries(_Employee)
                    .Where(aItem => aItem.EmployeeId == _Employee.EmployeeeId).FirstOrDefault();

            }
            catch (Exception e)
            {
                throw new Exception("Some error message");
            }

        }

        private static List<ISalaryEmployeeExempt> GetSalaries(IEmployee employee)
        {

            var SalaryList = new List<ISalaryEmployeeExempt>();

            SalaryList.Add(new SalaryEmployeeExempt()
            {
                EmployeeId = employee.EmployeeeId,
                IsExemptEmployee = true,
                NumberOfPayPeriod = 26,
                GrossSalaryAnnual = 52000
            });


            return SalaryList;
        }


    }
}
