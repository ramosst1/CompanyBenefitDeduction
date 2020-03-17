using System;
using System.Collections.Generic;
using System.Text;

namespace BenefitDeduction.Employees.FamilyMembers
{
    public interface IFamilyMemberRepository
    {

        List<IFamilyMember> GetFamilyMembers();

    }
}
