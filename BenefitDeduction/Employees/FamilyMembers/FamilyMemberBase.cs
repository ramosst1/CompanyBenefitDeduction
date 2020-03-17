using BenefitDeduction.Employees;
using System;
using System.Collections.Generic;
using System.Text;

namespace BenefitDeduction.Employees.FamilyMembers
{
    public abstract class FamilyMemberBase : PersonBase, IFamilyMember
    {
        public int EmployeeId { get; set; }
        public int FamilyMemberId { get; set; }
        public bool IsSpouse { get; set; } = false;
        public bool IsChild { get; set; } = false;

    }
}
