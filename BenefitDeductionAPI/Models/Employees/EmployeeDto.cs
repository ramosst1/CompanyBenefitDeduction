using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenefitDeductionAPI.Models.Employees
{
    public class EmployeeDto
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; } = "";
        public string LastName { get; set; }

        public int EmployeeId { get; internal set; }
        public bool IsExempt { get; set; }

    }
}
