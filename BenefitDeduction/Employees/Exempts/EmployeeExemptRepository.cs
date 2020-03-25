using System;
using System.Collections.Generic;
using System.Text;
using BenefitDeduction.Employees.FamilyMembers;
using System.Linq;

namespace BenefitDeduction.Employees.Exempts
{
    public class EmployeeExemptRepository : IEmployeeExemptRepository
    {
        public IEmployee GetEmployeeById(int employeeId)
        {

            try
            {

                var EmployeeList = GetEmployees();

                return EmployeeList.FirstOrDefault(aItem => aItem.EmployeeId == employeeId);
            }
            catch (Exception e) {

                throw new Exception("Some error message");
            }

        }

        public List<IFamilyMember> GetFamilyMembers(IEmployee employee)
        {
            try
            {

                var FamilyMemberList = new List<IFamilyMember>();

                var SpouseRepos = new EmployeeSpouseRepository(employee);
                var ChildrenRepos = new EmployeeChildRepository(employee);

                FamilyMemberList.AddRange(SpouseRepos.GetFamilyMembers());

                FamilyMemberList.AddRange(ChildrenRepos.GetFamilyMembers());

                return FamilyMemberList;
             
          }
            catch (Exception e) {
                throw new Exception("Some error message");
            }
        }

        public List<IEmployee> GetEmployees() {

            var EmployeeList = new List<IEmployee>();

            EmployeeList
                .Add(new Employee() {
                    IsExempt = true,
                    EmployeeId = 1,
                    FirstName = "John",
                    LastName = "Smith"
                    }
                );

            EmployeeList
                .Add(new Employee()
                {
                    IsExempt = true,
                    EmployeeId = 2,
                    FirstName = "Jill",
                    LastName = "Jackson"
                }
                );

            EmployeeList
                .Add(new Employee()
                {
                    IsExempt = true,
                    EmployeeId = 3,
                    FirstName = "Hector",
                    LastName = "Daniel"
                }
                );

            EmployeeList
                .Add(new Employee()
                {
                    IsExempt = true,
                    EmployeeId = 4,
                    FirstName = "James",
                    LastName = "Mankey"
                }
                );

            return EmployeeList;
        }
    }
}
