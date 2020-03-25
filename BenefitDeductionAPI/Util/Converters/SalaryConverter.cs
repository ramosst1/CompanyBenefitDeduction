using AutoMapper;
using BenefitDeduction.EmployeesSalary;
using BenefitDeductionAPI.Models.EmployeesSalary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenefitDeductionAPI.Util.Converters
{
    public class SalaryConverter
    {
        public static SalaryDto Convert(ISalary aSalary)
        {

            if (aSalary == null) return null;

            var MapperConfig = new MapperConfiguration(cfg => {
                cfg.CreateMap<ISalary, SalaryDto>();
            });

            IMapper iMapper = MapperConfig.CreateMapper();

            var Results = iMapper.Map<ISalary, SalaryDto>(aSalary);

            return Results;



        }

    }
}
