namespace BenefitDeduction.EmployeesSalary
{
    public interface ISalary
    {
        int EmployeeId { get;}
        int NumberOfPayPeriod { get;}
        double GrossSalaryAnnual { get;}
        bool IsManager { get;}
        bool IsExemptEmployee { get;}
        double GrossSalaryPerPayPeriod { get; }

    }
}