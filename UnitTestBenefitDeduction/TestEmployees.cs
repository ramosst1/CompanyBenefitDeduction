using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;
using Moq;
using BenefitDeduction.Employees;
using BenefitDeduction.Employees.FamilyMembers;
using BenefitDeduction.Employees.Exempts;

namespace Tests
{
    public class TestEmployees
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetEmployeesWithFamily()
        {

            var Employee = MockGetEmployee();

            var FamilySpouseRepos = MocktFamilyMemberSpouseRepos(Employee.Object);
            var FamilyChildrenRepos = MockFamilyMemberChildrenRepos(Employee.Object);
            var EmployeeExemptRepos = MockEmployeeExemptRepos();

            var FamilySpouseMember = MocktGetSpouse(Employee.Object);
            var FamilyChildrenMember = MockGetChildren(Employee.Object);

            FamilySpouseRepos.Setup(x => x.GetFamilyMembers(Employee.Object)).Returns(new List<IFamilyMember>{FamilySpouseMember.Object});
            FamilyChildrenRepos.Setup(x => x.GetFamilyMembers(Employee.Object)).Returns(FamilyChildrenMember);

            IEmployeeRepository EmployeeRepos = new EmployeeRepository(FamilySpouseRepos.Object,FamilyChildrenRepos.Object,EmployeeExemptRepos); 

            Assert.IsNotNull(Employee);

            var FamilyMembers = EmployeeRepos.GetFamilyMembers(Employee.Object);
            Assert.IsNotNull(FamilyMembers);

            var FamilySpouse = FamilyMembers.Where(aItem => aItem.IsSpouse == true);
            Assert.IsNotEmpty(FamilySpouse);

            var FamilyChilds = FamilyMembers.Where(aItem => aItem.IsChild == true);
            Assert.IsNotEmpty(FamilyChilds);

        }

        [Test]
        public void GetEmployeesWithNoFamily()
        {
            var Employee = MockGetEmployee();

            var FamilySpouseRepos = MocktFamilyMemberSpouseRepos(Employee.Object);
            var FamilyChildrenRepos = MockFamilyMemberChildrenRepos(Employee.Object);
            var EmployeeExemptRepos = MockEmployeeExemptRepos();

            FamilySpouseRepos.Setup(x => x.GetFamilyMembers(Employee.Object)).Returns(new List<IFamilyMember>());
            FamilyChildrenRepos.Setup(x => x.GetFamilyMembers(Employee.Object)).Returns(new List<IFamilyMember>());

            IEmployeeRepository EmployeeRepos = new EmployeeRepository(FamilySpouseRepos.Object,FamilyChildrenRepos.Object,EmployeeExemptRepos); 

            Assert.IsNotNull(Employee);

            var FamilyMembers = EmployeeRepos.GetFamilyMembers(Employee.Object);

            Assert.IsEmpty(FamilyMembers);

            var FamilySpouse = FamilyMembers.Where(aItem => aItem.IsSpouse == true);

            Assert.IsEmpty(FamilySpouse);

            var FamilyChilds = FamilyMembers.Where(aItem => aItem.IsChild == true);

            Assert.IsEmpty(FamilyChilds);

        }

        [Test]
        public void GetEmployeesWithSpouseOnlyPositive()
        {

            var Employee = MockGetEmployee();

            var FamilySpouseRepos = MocktFamilyMemberSpouseRepos(Employee.Object);
            var FamilyChildrenRepos = MockFamilyMemberChildrenRepos(Employee.Object);
            var EmployeeExemptRepos = MockEmployeeExemptRepos();

            var FamilySpouseMember = MocktGetSpouse(Employee.Object);

            FamilySpouseRepos.Setup(x => x.GetFamilyMembers(Employee.Object)).Returns(new List<IFamilyMember>{FamilySpouseMember.Object});
            FamilyChildrenRepos.Setup(x => x.GetFamilyMembers(Employee.Object)).Returns(new List<IFamilyMember>());

            IEmployeeRepository EmployeeRepos = new EmployeeRepository(FamilySpouseRepos.Object,FamilyChildrenRepos.Object,EmployeeExemptRepos); 

            Assert.IsNotNull(Employee);

            var FamilyMembers = EmployeeRepos.GetFamilyMembers(Employee.Object);

            var FamilySpouse = FamilyMembers.Where(aItem => aItem.IsSpouse == true);
            Assert.IsNotEmpty(FamilySpouse);

            var FamilyChilds = FamilyMembers.Where(aItem => aItem.IsChild == true);
            Assert.IsEmpty(FamilyChilds);

        }

        [Test]
        public void GetEmployeesWithChildrenOnly()
        {
            var Employee = MockGetEmployee();

            var FamilySpouseRepos = MocktFamilyMemberSpouseRepos(Employee.Object);
            var FamilyChildrenRepos = MockFamilyMemberChildrenRepos(Employee.Object);
            var EmployeeExemptRepos = MockEmployeeExemptRepos();

            var FamilyChildrenMember = MockGetChildren(Employee.Object);

            FamilySpouseRepos.Setup(x => x.GetFamilyMembers(Employee.Object)).Returns(new List<IFamilyMember>());
            FamilyChildrenRepos.Setup(x => x.GetFamilyMembers(Employee.Object)).Returns(FamilyChildrenMember);

            IEmployeeRepository EmployeeRepos = new EmployeeRepository(FamilySpouseRepos.Object,FamilyChildrenRepos.Object,EmployeeExemptRepos); 

            Assert.IsNotNull(Employee);

            var FamilyMembers = EmployeeRepos.GetFamilyMembers(Employee.Object);

            var FamilySpouse = FamilyMembers.Where(aItem => aItem.IsSpouse == true);
            Assert.IsEmpty(FamilySpouse);

            var FamilyChilds = FamilyMembers.Where(aItem => aItem.IsChild == true);
            Assert.IsNotEmpty(FamilyChilds);

        }

        private Mock<IFamilyMemberSpouseRepository>  MocktFamilyMemberSpouseRepos(IEmployee employee){


            Mock<IFamilyMemberSpouseRepository> Results = new Mock<IFamilyMemberSpouseRepository>();

            return Results;

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
        private Mock<IFamilyMemberChildRepository>  MockFamilyMemberChildrenRepos(IEmployee employee){

            Mock<IFamilyMemberChildRepository> Results = new Mock<IFamilyMemberChildRepository>();
            
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

        private IEmployeeExemptRepository  MockEmployeeExemptRepos(){


            Mock<IEmployeeExemptRepository> Results = new Mock<IEmployeeExemptRepository>();

            return Results.Object;


        }

        private Mock<IEmployee> MockGetEmployee() {

            var AEmployee = new Mock<IEmployee>().SetupAllProperties();
            AEmployee.SetupGet(x => x.EmployeeId).Returns(1);

            AEmployee.Object.FirstName  = "John";
            AEmployee.Object.LastName = "Smith";

            return AEmployee;
        }

    }
}