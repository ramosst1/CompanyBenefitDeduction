using System;
using System.Collections.Generic;
using System.Text;

namespace BenefitDeduction.Employees
{
    public abstract class EmployeeBase : PersonBase, IEmployee
    {
        public int EmployeeeId { get; internal set; }
        public bool IsExempt { get; set; }

    }
}
