using NUnit.Framework;
using BenefitDeduction.Employees;
using System.Linq;

namespace Tests
{
    public class TestEmployees
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetEmployeesWithFamilyPositive()
        {
            IEmployeeRepository EmployeeRepos = new EmployeeRepository(null,null); //TO DO: Fix Unit Test later

            var Employee = EmployeeRepos.GetEmployeeById(1);
            Assert.IsNotNull(Employee);

            var FamilyMembers = EmployeeRepos.GetFamilyMembers(Employee);
            Assert.IsNotNull(FamilyMembers);

            var FamilySpouse = FamilyMembers.Where(aItem => aItem.IsSpouse == true);
            Assert.IsNotEmpty(FamilySpouse);

            var FamilyChilds = FamilyMembers.Where(aItem => aItem.IsChild == true);
            Assert.IsNotEmpty(FamilyChilds);

        }

        [Test]
        public void GetEmployeesWithFamilyNegative()
        {
            IEmployeeRepository EmployeeRepos = new EmployeeRepository(null, null); //TO DO: Fix Unit Test later

            var Employee = EmployeeRepos.GetEmployeeById(2);

            Assert.IsNotNull(Employee);

            var FamilyMembers = EmployeeRepos.GetFamilyMembers(Employee);

            Assert.IsEmpty(FamilyMembers);

            var FamilySpouse = FamilyMembers.Where(aItem => aItem.IsSpouse == true);

            Assert.IsEmpty(FamilySpouse);

            var FamilyChilds = FamilyMembers.Where(aItem => aItem.IsChild == true);

            Assert.IsEmpty(FamilyChilds);

        }

        [Test]
        public void GetEmployeesWithSpouseOnlyPositive()
        {
            IEmployeeRepository EmployeeRepos = new EmployeeRepository(null, null); //TO DO: Fix Unit Test later

            var Employee = EmployeeRepos.GetEmployeeById(3);
            Assert.IsNotNull(Employee);

            var FamilyMembers = EmployeeRepos.GetFamilyMembers(Employee);

            var FamilySpouse = FamilyMembers.Where(aItem => aItem.IsSpouse == true);
            Assert.IsNotEmpty(FamilySpouse);

            var FamilyChilds = FamilyMembers.Where(aItem => aItem.IsChild == true);
            Assert.IsEmpty(FamilyChilds);

        }

        [Test]
        public void GetEmployeesWithSpouseOnlyNegative()
        {
            IEmployeeRepository EmployeeRepos = new EmployeeRepository(null, null); //TO DO: Fix Unit Test later

            var Employee = EmployeeRepos.GetEmployeeById(2);
            Assert.IsNotNull(Employee);

            var FamilyMembers = EmployeeRepos.GetFamilyMembers(Employee);

            var FamilySpouse = FamilyMembers.Where(aItem => aItem.IsSpouse == true);
            Assert.IsEmpty(FamilySpouse);

            var FamilyChilds = FamilyMembers.Where(aItem => aItem.IsChild == true);
            Assert.IsEmpty(FamilyChilds);

        }


        [Test]
        public void GetEmployeesWithChildrenOnlyPositive()
        {
            IEmployeeRepository EmployeeRepos = new EmployeeRepository(null, null); //TO DO: Fix Unit Test later

            var Employee = EmployeeRepos.GetEmployeeById(4);
            Assert.IsNotNull(Employee);

            var FamilyMembers = EmployeeRepos.GetFamilyMembers(Employee);

            var FamilySpouse = FamilyMembers.Where(aItem => aItem.IsSpouse == true);
            Assert.IsEmpty(FamilySpouse);

            var FamilyChilds = FamilyMembers.Where(aItem => aItem.IsChild == true);
            Assert.IsNotEmpty(FamilyChilds);

        }

        [Test]
        public void GetEmployeesWithChildrenOnlyNegative()
        {
            IEmployeeRepository EmployeeRepos = new EmployeeRepository(null, null); //TO DO: Fix Unit Test later

            var Employee = EmployeeRepos.GetEmployeeById(2);
            Assert.IsNotNull(Employee);

            var FamilyMembers = EmployeeRepos.GetFamilyMembers(Employee);

            var FamilySpouse = FamilyMembers.Where(aItem => aItem.IsSpouse == true);
            Assert.IsEmpty(FamilySpouse);

            var FamilyChilds = FamilyMembers.Where(aItem => aItem.IsChild == true);
            Assert.IsEmpty(FamilyChilds);

        }


    }
}