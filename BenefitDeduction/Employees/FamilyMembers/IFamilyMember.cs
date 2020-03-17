
namespace BenefitDeduction.Employees.FamilyMembers
{
    public interface IFamilyMember: IPerson
    {
        int EmployeeId { get; set; }
        int FamilyMemberId { get; set; }
        bool IsChild { get; set; }
        bool IsSpouse { get; set; }
    }
}