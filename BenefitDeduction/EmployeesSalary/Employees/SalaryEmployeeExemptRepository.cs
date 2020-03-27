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

        private static decimal SalaryIncrementor = 30000.00m;
        private static List<ISalaryEmployeeExempt> SalaryList = new List<ISalaryEmployeeExempt>();

        public SalaryEmployeeExemptRepository(IEmployee employee)
        {
            _Employee = employee;
        }

        public ISalary GetSalary()
        {
            try
            {
                return GetSalaries(_Employee)
                    .Where(aItem => aItem.EmployeeId == _Employee.EmployeeId).FirstOrDefault();

            }
            catch (Exception e)
            {
                throw new Exception("Some error message");
            }

        }

        private static List<ISalaryEmployeeExempt> GetSalaries(IEmployee employee)
        {

            var AEmployee = SalaryList.Where(aItem => aItem.EmployeeId == employee.EmployeeId).FirstOrDefault();

            if (AEmployee != null) return SalaryList;

            lock (new object()) {
                SalaryIncrementor += 10000;

                SalaryList.Add(new SalaryEmployeeExempt()
                {
                    EmployeeId = employee.EmployeeId,
                    IsExemptEmployee = true,
                    NumberOfPayPeriod = 26,
                    GrossSalaryAnnual = SalaryIncrementor
                });

            }

            return SalaryList;

        }


    }
}
