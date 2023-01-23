using Ecolab.Ecolab3D.Backend.FunctionApplication.Infrastructure.Persistence.EntityFrameworkModels;

namespace Ecolab3DModel.Repositories
{
    public interface ICorporateShiftsServices
    {
        Task<IEnumerable<CorporateShifts>> GetAllAsync();
        Task<IEnumerable<CorporateShifts>> GetAsync(int Id);
        //Task<CorporateShifts>AddAsync(CorporateShifts corporateShifts);
        Task<IEnumerable<CorporateShifts>> UpdateAsync(int Id, IEnumerable<CorporateShifts> corporateShifts);
        Task<CorporateShifts> DeleteAsync(int Id);
        //Task<IEnumerable<CorporateShifts>> UpdateAsync(int id);
    }
}
