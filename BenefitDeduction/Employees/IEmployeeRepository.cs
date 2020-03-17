using BenefitDeduction.Employees.FamilyMembers;
using System.Collections.Generic;

namespace BenefitDeduction.Employees
{
    public interface IEmployeeRepository
    {
        IEmployee GetEmployeeById(int employeeId);
        List<IFamilyMember> GetFamilyMembers(IEmployee employee);
    }
}