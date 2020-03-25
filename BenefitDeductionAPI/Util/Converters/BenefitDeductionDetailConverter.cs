using AutoMapper;
using BenefitDeduction.EmployeeBenefitDeduction;
using BenefitDeductionAPI.Models.EmployeeBenefitDeduction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenefitDeductionAPI.Util.Converters
{
    public class BenefitDeductionDetailConverter
    {
        public static BenefitDeductionDetailDto Convert(IBenefitDeductionDetail aBenefitDeductDetail)
        {

            if (aBenefitDeductDetail == null) return null;

            var MapperConfig = new MapperConfiguration(cfg => {
                cfg.CreateMap<IBenefitDeductionDetail, BenefitDeductionDetailDto>();
                cfg.CreateMap<IBenefitDeductionItem, BenefitDeductionItemDto>();
            });

            IMapper iMapper = MapperConfig.CreateMapper();

            var Results = iMapper.Map<IBenefitDeductionDetail, BenefitDeductionDetailDto>(aBenefitDeductDetail);

            return Results;



        }

    }
}
