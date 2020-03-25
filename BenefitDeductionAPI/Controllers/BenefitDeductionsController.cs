using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BenefitDeduction.EmployeeBenefitDeduction;
using BenefitDeduction.Employees;
using BenefitDeduction.Employees.FamilyMembers;
using BenefitDeduction.EmployeesSalary;
using BenefitDeductionAPI.Models.EmployeeBenefitDeduction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BenefitDeductionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BenefitDeductionsController : ControllerBase
    {

        [HttpGet("{employeeId}")]
        public ActionResult<BenefitDeductionDetailDto> Get(int employeeId)
        {
            IEmployeeRepository EmployeeRepos = new EmployeeRepository();

            var AEmployee = EmployeeRepos.GetEmployeeById(employeeId);

            List<IFamilyMember> FamilyMembers = EmployeeRepos.GetFamilyMembers(AEmployee);

            ISalaryRepository SalaryEmployeeRepos = new SalaryRepository(AEmployee);

            ISalary AEmployeeSalary = SalaryEmployeeRepos.GetSalary();

            IBenefitDeductionRepository BenefitDeductionRepos =
                new BenefitDeductionRepository(AEmployee, FamilyMembers, AEmployeeSalary);

            IBenefitDeductionDetail ABenefitDeductionDetail =
                BenefitDeductionRepos.CalculateBenefitDeductionDetail();


            var ABenefitDeductionDetailDto = Util.Converters.
                BenefitDeductionDetailConverter.Convert(ABenefitDeductionDetail);

            return ABenefitDeductionDetailDto;

        }


    }
}