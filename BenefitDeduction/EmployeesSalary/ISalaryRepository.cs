using BenefitDeduction.Employees;

namespace BenefitDeduction.EmployeesSalary
{
    public interface ISalaryRepository
    {
        ISalary GetSalary(IEmployee employee);
    }
}