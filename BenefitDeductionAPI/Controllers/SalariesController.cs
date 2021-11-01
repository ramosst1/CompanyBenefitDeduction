using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BenefitDeduction.Employees;
using BenefitDeduction.EmployeesSalary;
using BenefitDeductionAPI.Models.EmployeesSalary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BenefitDeductionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalariesController : ControllerBase
    {
        private IEmployeeRepository _EmployeeRepos;
        private ISalaryRepository _SalaryEmployeeRepos;

        public SalariesController(IEmployeeRepository employeeRepos, ISalaryRepository salaryEmployeeRepos)
        {
            _EmployeeRepos = employeeRepos;
            _SalaryEmployeeRepos = salaryEmployeeRepos;
        }

        [HttpGet("{employeeId}")]
        public ActionResult<SalaryDto> Get(int employeeId)
        {

            IEmployee AEmployee = _EmployeeRepos.GetEmployeeById(employeeId);

            ISalary AEmployeeSalary = _SalaryEmployeeRepos.GetSalary(AEmployee);

            var ASalaryDto = Util.Converters.SalaryConverter.Convert(AEmployeeSalary);

            return ASalaryDto;
        }

    }
}
