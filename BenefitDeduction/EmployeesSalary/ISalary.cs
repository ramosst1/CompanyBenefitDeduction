namespace BenefitDeduction.EmployeesSalary
{
    public interface ISalary
    {
        int EmployeeId { get;}
        int NumberOfPayPeriod { get;}
        decimal GrossSalaryAnnual { get;}
        bool IsManager { get;}
        bool IsExemptEmployee { get;}
        decimal GrossSalaryPerPayPeriod { get; }

    }
}