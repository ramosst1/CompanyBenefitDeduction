namespace BenefitDeduction.EmployeeBenefitDeduction
{
    public interface IBenefitDeductionRepository
    {
        IBenefitDeductionDetail CalculateBenefitDeductionDetail();
    }
}