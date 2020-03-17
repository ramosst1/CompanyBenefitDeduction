using BenefitDeduction.Employees;
using BenefitDeduction.EmployeeBenefitDeduction;
using BenefitDeduction.EmployeesSalary;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BenefitDeduction.Employees.FamilyMembers;

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

            IEmployeeRepository EmployeeRepos = new EmployeeRepository();

            var AEmployee = EmployeeRepos.GetEmployeeById(1);
            Assert.IsNotNull(AEmployee);

            List <IFamilyMember> FamilyMembers = EmployeeRepos.GetFamilyMembers(AEmployee);
            Assert.IsNotNull(FamilyMembers);

            ISalaryRepository SalaryEmployeeRepos = new SalaryRepository(AEmployee);

            ISalary AEmployeeSalary = SalaryEmployeeRepos.GetSalary();

            Assert.IsNotNull(AEmployeeSalary);

            IBenefitDeductionRepository BenefitDeductionRepos =
                new BenefitDeductionRepository(AEmployee, FamilyMembers, AEmployeeSalary);

            IBenefitDeductionDetail ABenefitDeductionDetail =  
                BenefitDeductionRepos.CalculateBenefitDeductionDetail();

            Assert.IsNotNull(ABenefitDeductionDetail);



        }
    }
}
