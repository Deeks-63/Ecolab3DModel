using Ecolab.Ecolab3D.Backend.FunctionApplication.Infrastructure.Persistence.EntityFrameworkModels;

namespace Ecolab3DModel.Repositories
{
    public interface ICorporateShiftsServices
    {
        Task<IEnumerable<CorporateShifts>> GetAllAsync();
    }
}
