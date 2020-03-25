
namespace BenefitDeduction.Employees
{
    public interface IEmployee: IPerson
    {
        int EmployeeId { get;}
        bool IsExempt { get; }
    }
}