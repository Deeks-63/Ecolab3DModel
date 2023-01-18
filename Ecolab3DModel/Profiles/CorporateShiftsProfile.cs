using AutoMapper;
using Ecolab.Ecolab3D.Backend.FunctionApplication.Infrastructure.Persistence.EntityFrameworkModels;

namespace Ecolab3DModel.Profiles
{
    public class CorporateShiftsProfile: Profile
    {
        public CorporateShiftsProfile()
        {
            CreateMap<CorporateShifts, Models.DTO.CorporateShifts>().ReverseMap();
        }
    }
}
