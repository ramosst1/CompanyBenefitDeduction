using System;
using System.Collections.Generic;
using System.Text;

namespace BenefitDeduction.Employees
{
    public abstract class EmployeeBase : PersonBase, IEmployee
    {
        public int EmployeeId { get; internal set; }
        public bool IsExempt { get; set; }

    }
}
