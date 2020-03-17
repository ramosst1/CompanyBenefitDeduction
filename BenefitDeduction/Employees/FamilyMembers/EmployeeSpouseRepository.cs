using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BenefitDeduction.Employees.FamilyMembers
{
    internal class EmployeeSpouseRepository: IFamilyMemberRepository
    {
        private IEmployee _Employee;
        internal EmployeeSpouseRepository(IEmployee employee)
        {
            _Employee = employee;
        }

        public List<IFamilyMember> GetFamilyMembers()
        {

            try
            {

                var FamilyMemberList = new List<IFamilyMember>();

                FamilyMemberList.Add(
                    new EmployeeSpouse()
                    {
                        EmployeeId = 1,
                        FamilyMemberId = 30,
                        FirstName ="Jane" ,
                        MiddleName = "Alice",
                        LastName ="Smith",
                        IsSpouse = true
                    }
                );
                FamilyMemberList.Add(
                    new EmployeeSpouse()
                    {
                        EmployeeId = 3,
                        FamilyMemberId = 31,
                        FirstName = "Elizabeth",
                        LastName = "Daniel",
                        IsSpouse = true
                    }
                );


                return FamilyMemberList.Where(aItem => aItem.EmployeeId == _Employee.EmployeeeId).ToList();

            }
            catch (Exception e)
            {
                throw new Exception("Some error message");
            }

        }
    }
}
