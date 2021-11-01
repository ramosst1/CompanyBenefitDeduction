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

            IEmployeeRepository EmployeeRepos = new EmployeeRepository(null, null); //TO DO: Fix Unit Test later

            IEmployee AEmployee = EmployeeRepos.GetEmployeeById(1);

            Assert.IsNotNull(AEmployee);

            ISalaryRepository SalaryEmployeeRepos = new SalaryRepository();

            ISalary AEmployeeSalary = SalaryEmployeeRepos.GetSalary(AEmployee);

            Assert.IsNotNull(AEmployeeSalary);

        }

        /// Do some other testing.

    }
}
