namespace BenefitDeduction.EmployeeBenefitDeduction
{
    public interface IBenefitDeductionItem
    {
        int EmployeeId { get; }
        int FamilyMemberId { get; }
        string FirstName { get; }
        string LastName { get; }
        string MiddleName { get; }
        bool IsChild { get; }
        bool IsEmployee { get; }
        bool IsSpouse { get; }
        int NumberOfPayPeriod { get; }
        decimal AnnualCostGross { get; }
        decimal AnnualCostNet { get; }
        int AnnualDiscountPerentage { get; }

        decimal PerPayPeriodCostGross { get; }
        decimal PerPayPeriodCostNet { get; }
    }
}