
namespace BenefitDeduction.Employees
{
    public interface IEmployee: IPerson
    {
        int EmployeeeId { get;}
        bool IsExempt { get; }
    }
}