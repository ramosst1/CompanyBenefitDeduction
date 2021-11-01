using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BenefitDeduction.Employees.FamilyMembers
{
    public class EmployeeSpouseRepository: IFamilyMemberSpouseRepository
    {
        public EmployeeSpouseRepository()
        {
        }

        public List<IFamilyMember> GetFamilyMembers(IEmployee employee)
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
                        FirstName = "Alexandria",
                        LastName = "Daniel",
                        IsSpouse = true
                    }
                );


                return FamilyMemberList.Where(aItem => aItem.EmployeeId == employee.EmployeeId).ToList();

            }
            catch (Exception e)
            {
                throw new Exception("Some error message");
            }

        }
    }
}
