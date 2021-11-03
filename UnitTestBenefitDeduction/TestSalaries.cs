using BenefitDeduction.Employees;
using BenefitDeduction.EmployeesSalary;
using BenefitDeduction.EmployeesSalary.Employees;
using NUnit.Framework;
using Moq;

namespace UnitTestBenefitDeduction
{
    class TestSalaries
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetEmployeeSalary() {

            var Employee = MockGetEmployee();

            ISalaryEmployeeExemptRepository SalaryEmployeeExemptRepos = new SalaryEmployeeExemptRepository(Employee.Object); 

            ISalaryRepository SalaryEmployeeRepos = new SalaryRepository(SalaryEmployeeExemptRepos);

            ISalary AEmployeeSalary = SalaryEmployeeRepos.GetSalary(Employee.Object);

            Assert.IsNotNull(AEmployeeSalary);

        }

        private Mock<IEmployee> MockGetEmployee() {

            var AEmployee = new Mock<IEmployee>().SetupAllProperties();
            AEmployee.SetupGet(x => x.EmployeeId).Returns(1);

            AEmployee.Object.FirstName  = "John";
            AEmployee.Object.LastName = "Smith";
            AEmployee.SetupGet(x => x.IsExempt).Returns(true);

            return AEmployee;
        }


        /// Do some other testing.

    }
}
