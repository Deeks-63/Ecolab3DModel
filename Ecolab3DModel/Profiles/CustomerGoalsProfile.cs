using AutoMapper;
using Ecolab.Ecolab3D.Backend.FunctionApplication.Infrastructure.Persistence.EntityFrameworkModels;

namespace Ecolab3DModel.Profiles
{
    public class CustomerGoalsProfile : Profile
    {
        public CustomerGoalsProfile()
        {
            CreateMap<CustomerGoal, Models.DTO.CustomerGoal>().ReverseMap();
        }
    }
}
