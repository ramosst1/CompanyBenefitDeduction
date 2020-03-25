using BenefitDeduction.Employees.FamilyMembers;
using System.Collections.Generic;

namespace BenefitDeduction.Employees
{
    public interface IEmployeeRepository
    {
        List <IEmployee> GetEmployees();

        IEmployee GetEmployeeById(int employeeId);
        List<IFamilyMember> GetFamilyMembers(IEmployee employee);
    }
}