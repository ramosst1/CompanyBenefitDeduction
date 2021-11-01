using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BenefitDeduction.Employees.FamilyMembers
{
    public class EmployeeChildRepository: IFamilyMemberChildRepository
    {

        public EmployeeChildRepository()
        {
        }

        public List<IFamilyMember> GetFamilyMembers(IEmployee employee)
        {

            try {
                var FamilyMemberList = new List<IFamilyMember>();

                FamilyMemberList.Add(
                    new EmployeeSpouse()
                    {
                        EmployeeId = 1,
                        FamilyMemberId = 50,
                        FirstName = "Frank",
                        LastName = "Smith",
                        IsChild = true
                    }
                );

                FamilyMemberList.Add(
                    new EmployeeSpouse()
                    {
                        EmployeeId = 1,
                        FamilyMemberId = 51,
                        FirstName = "Betty",
                        LastName = "Smith",
                        IsChild = true
                    }
                );

                FamilyMemberList.Add(
                    new EmployeeSpouse()
                    {
                        EmployeeId = 1,
                        FamilyMemberId = 51,
                        FirstName = "Anna",
                        LastName = "Smith",
                        IsChild = true
                    }
                );

                FamilyMemberList.Add(
                    new EmployeeSpouse()
                    {
                        EmployeeId = 4,
                        FamilyMemberId = 52,
                        FirstName = "James Jr",
                        LastName = "Mankey",
                        IsChild = true
                    }
                );

                FamilyMemberList.Add(
                    new EmployeeSpouse()
                    {
                        EmployeeId = 4,
                        FamilyMemberId = 53,
                        FirstName = "Peter",
                        LastName = "Mankey",
                        IsChild = true
                    }
                );

                return FamilyMemberList.Where(aItem => aItem.EmployeeId == employee.EmployeeId).ToList();


            } catch (Exception e) {
                throw new Exception("Some error message");
            }

        }

    }
}
