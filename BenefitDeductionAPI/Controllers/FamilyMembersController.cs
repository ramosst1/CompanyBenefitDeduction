using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BenefitDeduction.Employees;
using BenefitDeductionAPI.Models.FamilyMembers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BenefitDeductionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyMembersController : ControllerBase
    {
        [HttpGet("EmployeeFamilyMembers/{employeeId}")]
        public ActionResult <List<FamilyMemberDto>> GetEmployeeFamilyMembers(int employeeId)
        {
            IEmployeeRepository EmployeeRepos = new EmployeeRepository();

            var Employee = EmployeeRepos.GetEmployeeById(employeeId);

            var FamilyMembers = EmployeeRepos.GetFamilyMembers(Employee);

            var FamilyMemberDtos = Util.Converters.FamiliyMemberConverter.Convert(FamilyMembers);

            return FamilyMemberDtos;
        }

    }
}
