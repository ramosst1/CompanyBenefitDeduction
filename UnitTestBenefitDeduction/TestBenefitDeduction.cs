using BenefitDeduction.Employees;
using BenefitDeduction.EmployeeBenefitDeduction;
using BenefitDeduction.EmployeesSalary;
using BenefitDeduction.Employees.FamilyMembers;
using BenefitDeduction.EmployeeBenefitDeduction.Employees;
using BenefitDeduction.EmployeeBenefitDeduction.Employees.Calculators;
using NUnit.Framework;
using System.Collections.Generic;
using Moq;
namespace UnitTestBenefitDeduction
{
    class TestBenefitDeduction
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetBenefitDeductionsPositive()
        {

            var Employee = MockGetEmployee();

            var FamilySpouse = MocktGetSpouse(Employee.Object);
            var FamilyMembers = MockGetChildren(Employee.Object);

            FamilyMembers.Add(FamilySpouse.Object);

            var EmployeeSalary = MockGetEmployeeSalary(Employee.Object);

            var CalculateDeductionItemsRespos = new CalculateDeductionItemsRespository();
            var CalculateDeductionDetailRespos = new CalculateDeductionDetailRespository();

            var DeductionEmployeeRepos = new DeductionEmployeeRepository(CalculateDeductionItemsRespos,CalculateDeductionDetailRespos);

            IBenefitDeductionRepository BenefitDeductionRepos =
                new BenefitDeductionRepository(DeductionEmployeeRepos);

            IBenefitDeductionDetail ABenefitDeductionDetail =  
                BenefitDeductionRepos.CalculateBenefitDeductionDetail(Employee.Object, FamilyMembers, EmployeeSalary.Object);

            Assert.IsNotNull(ABenefitDeductionDetail);

        }

        private Mock<ISalary> MockGetEmployeeSalary(IEmployee employee){

            var EmployeeSalary = new Mock<ISalary>().SetupAllProperties();

            EmployeeSalary.SetupGet(x => x.EmployeeId).Returns(employee.EmployeeId);
            EmployeeSalary.SetupGet(x => x.IsExemptEmployee).Returns(true);
            EmployeeSalary.SetupGet(x => x.GrossSalaryAnnual).Returns(30000.00m);
            EmployeeSalary.SetupGet(x => x.NumberOfPayPeriod).Returns(26);

            return EmployeeSalary;
        }
    
        private Mock<IFamilyMember>  MocktGetSpouse(IEmployee employee){

            var Results = new Mock<IFamilyMember>().SetupAllProperties();
            Results.Object.EmployeeId = 1;
            Results.Object.FirstName = "Jill";
            Results.Object.LastName = "Smith";
            Results.Object.IsSpouse = true;
            Results.Object.FamilyMemberId = 2;

            return Results;

        }

        private List<IFamilyMember> MockGetChildren(IEmployee employee){

            var FamilyChild1Member = new Mock<IFamilyMember>().SetupAllProperties();
            FamilyChild1Member.Object.EmployeeId = 1;
            FamilyChild1Member.Object.FirstName = "Peter";
            FamilyChild1Member.Object.LastName = "Smith";
            FamilyChild1Member.Object.IsChild = true;
            FamilyChild1Member.Object.FamilyMemberId = 3;

            var FamilyChild2Member = new Mock<IFamilyMember>().SetupAllProperties();
            FamilyChild2Member.Object.EmployeeId = 1;
            FamilyChild2Member.Object.FirstName = "Amy";
            FamilyChild2Member.Object.LastName = "Smith";
            FamilyChild2Member.Object.IsChild = true;
            FamilyChild1Member.Object.FamilyMemberId = 4;

            return new List<IFamilyMember>{FamilyChild1Member.Object, FamilyChild2Member.Object};

        }

        private Mock<IEmployee> MockGetEmployee() {

            var AEmployee = new Mock<IEmployee>().SetupAllProperties();
            AEmployee.SetupGet(x => x.EmployeeId).Returns(1);

            AEmployee.Object.FirstName  = "John";
            AEmployee.Object.LastName = "Smith";
            AEmployee.SetupGet(x => x.IsExempt).Returns(true);

            return AEmployee;
        }

    }
}
