using BenefitDeduction.Employees;
using BenefitDeduction.EmployeesSalary;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestBenefitDeduction
{
    class TestSalaries
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetEmployeeSalaryPositive() {

            IEmployeeRepository EmployeeRepos = new EmployeeRepository();

            IEmployee AEmployee = EmployeeRepos.GetEmployeeById(1);

            Assert.IsNotNull(AEmployee);

            ISalaryRepository SalaryEmployeeRepos = new SalaryRepository(AEmployee);

            ISalary AEmployeeSalary = SalaryEmployeeRepos.GetSalary();

            Assert.IsNotNull(AEmployeeSalary);

        }

        /// Do some other testing.

    }
}
