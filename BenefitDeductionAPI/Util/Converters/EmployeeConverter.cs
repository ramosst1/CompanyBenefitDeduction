using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BenefitDeduction.Employees;
using BenefitDeductionAPI.Models.Employees;

namespace BenefitDeductionAPI.Util.Converters
{
    public class EmployeeConverter
    {

        public static List <EmployeeDto> Convert(List <IEmployee> employees) {

            var Results = new List<EmployeeDto>();

            employees.ForEach(delegate (IEmployee aEmployee)
            {
                Results.Add(Convert(aEmployee));
            });

            return Results;
        }

            public static EmployeeDto Convert(IEmployee aEmployee)
        {

            if (aEmployee == null) return null;

            var MapperConfig = new MapperConfiguration(cfg => {
                cfg.CreateMap<IEmployee, EmployeeDto>();
            });

            IMapper iMapper = MapperConfig.CreateMapper();

            var Results = iMapper.Map<IEmployee, EmployeeDto>(aEmployee);

            return Results;



        }

    }
}
