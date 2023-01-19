using Ecolab.Ecolab3D.Backend.FunctionApplication.Infrastructure.Persistence.EntityFrameworkModels;

namespace Ecolab3DModel.Repositories
{
    public interface ICorporateShiftsServices
    {
        Task<IEnumerable<CorporateShifts>> GetAllAsync();
        Task<IEnumerable<CorporateShifts>> GetAsync(int CustomerKey);
        //Task<CorporateShifts>AddAsync(CorporateShifts corporateShifts);
        Task<CorporateShifts>UpdateAsync(int CustomerKey, CorporateShifts corporateShifts);
    }
}
