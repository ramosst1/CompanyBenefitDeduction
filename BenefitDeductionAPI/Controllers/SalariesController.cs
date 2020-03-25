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

        [HttpGet("{employeeId}")]
        public ActionResult<SalaryDto> Get(int employeeId)
        {
            IEmployeeRepository EmployeeRepos = new EmployeeRepository();

            IEmployee AEmployee = EmployeeRepos.GetEmployeeById(employeeId);
            ISalaryRepository SalaryEmployeeRepos = new SalaryRepository(AEmployee);

            ISalary AEmployeeSalary = SalaryEmployeeRepos.GetSalary();

            var ASalaryDto = Util.Converters.SalaryConverter.Convert(AEmployeeSalary);

            return ASalaryDto;
        }

    }
}
