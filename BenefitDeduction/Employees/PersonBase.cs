using System;
using System.Collections.Generic;
using System.Text;

namespace BenefitDeduction.Employees
{
    public abstract class PersonBase : IPerson
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; } = "";
        public string LastName { get; set; }

    }
}
