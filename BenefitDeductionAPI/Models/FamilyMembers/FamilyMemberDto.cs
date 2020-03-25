using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenefitDeductionAPI.Models.FamilyMembers
{
    public class FamilyMemberDto
    {

        public int EmployeeId { get; set; }
        public int FamilyMemberId { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; } = "";
        public string LastName { get; set; }

        public bool IsSpouse { get; set; } = false;
        public bool IsChild { get; set; } = false;


    }
}
