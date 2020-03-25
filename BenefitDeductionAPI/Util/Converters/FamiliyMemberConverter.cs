using AutoMapper;
using BenefitDeduction.Employees.FamilyMembers;
using BenefitDeductionAPI.Models.FamilyMembers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenefitDeductionAPI.Util.Converters
{
    public class FamiliyMemberConverter
    {
        public static List <FamilyMemberDto> Convert(List <IFamilyMember> familyMembers) {

            var Results = new List<FamilyMemberDto>();

            familyMembers.ForEach(delegate (IFamilyMember aFamilyMember)
            {
                Results.Add(Convert(aFamilyMember));
            });


            return Results;
        }

        private static FamilyMemberDto Convert(IFamilyMember aFamilyMember)
        {

            if (aFamilyMember == null) return null;

            var MapperConfig = new MapperConfiguration(cfg => {
                cfg.CreateMap<IFamilyMember, FamilyMemberDto>();
            });

            IMapper iMapper = MapperConfig.CreateMapper();

            var Results = iMapper.Map<IFamilyMember, FamilyMemberDto>(aFamilyMember);

            return Results;



        }

    }
}
