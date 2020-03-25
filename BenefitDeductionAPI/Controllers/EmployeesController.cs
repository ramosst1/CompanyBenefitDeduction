using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BenefitDeduction.Employees;
using BenefitDeductionAPI.Models.Employees;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BenefitDeductionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {


        // GET: api/Employees/5
        [HttpGet]
        public ActionResult<List <EmployeeDto>> Get()
        {
            IEmployeeRepository EmployeeRepos = new EmployeeRepository();

            var Employees = EmployeeRepos.GetEmployees();

            var EmployeeDto = Util.Converters.EmployeeConverter.Convert(Employees);

            return EmployeeDto;
        }

        // GET: api/Employees/5
        [HttpGet("{employeeId}")]
        public ActionResult<EmployeeDto> Get(int employeeId)
        {
            IEmployeeRepository EmployeeRepos = new EmployeeRepository();

            var Employee = EmployeeRepos.GetEmployeeById(employeeId);

            var EmployeeDto = Util.Converters.EmployeeConverter.Convert(Employee);

            return EmployeeDto;
        }

    }
}
