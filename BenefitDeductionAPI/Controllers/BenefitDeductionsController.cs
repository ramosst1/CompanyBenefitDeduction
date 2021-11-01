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
        
        private IEmployeeRepository _EmployeeRepos;
        private ISalaryRepository _SalaryEmployeeRepos;
        private IBenefitDeductionRepository _BenefitDeductionRepos;

        public BenefitDeductionsController(
            IEmployeeRepository employeeRepos, 
            ISalaryRepository salaryEmployeeRepos,
            IBenefitDeductionRepository benefitDeductionRepos            
        )
        {
            _EmployeeRepos = employeeRepos;    
            _SalaryEmployeeRepos = salaryEmployeeRepos;
            _BenefitDeductionRepos = benefitDeductionRepos;
        }

        [HttpGet("{employeeId}")]
        public ActionResult<BenefitDeductionDetailDto> Get(int employeeId)
        {

            var AEmployee = _EmployeeRepos.GetEmployeeById(employeeId);

            List<IFamilyMember> FamilyMembers = _EmployeeRepos.GetFamilyMembers(AEmployee);

            ISalary AEmployeeSalary = _SalaryEmployeeRepos.GetSalary(AEmployee);

            IBenefitDeductionDetail ABenefitDeductionDetail =
                _BenefitDeductionRepos.CalculateBenefitDeductionDetail(AEmployee, FamilyMembers, AEmployeeSalary);


            var ABenefitDeductionDetailDto = Util.Converters.
                BenefitDeductionDetailConverter.Convert(ABenefitDeductionDetail);

            return ABenefitDeductionDetailDto;

        }


    }
}