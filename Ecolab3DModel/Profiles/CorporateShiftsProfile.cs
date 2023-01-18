using AutoMapper;

namespace Ecolab3DModel.Profiles
{
    public class CorporateShiftsProfile: Profile
    {
        public CorporateShiftsProfile()
        {
            CreateMap<Models.Domain.CorporateShifts, Models.DTO.CorporateShifts>().ReverseMap();
        }
    }
}
