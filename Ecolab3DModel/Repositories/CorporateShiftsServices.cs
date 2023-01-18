using Ecolab.Ecolab3D.Backend.FunctionApplication.Infrastructure.Persistence.EntityFrameworkModels;
using Ecolab3DModel.Data;
using Microsoft.EntityFrameworkCore;

namespace Ecolab3DModel.Repositories
{
    public class CorporateShiftsServices : ICorporateShiftsServices
    {
        private readonly Ecolab3DDbContext ecolab3DDbContext;

        //I would want to task the databse and get the shifts from there so i made a constructor.
        //So we are injecing the DbContext through the constructor and then we will use the private 
        //property inside the method to get all the regions.
        public CorporateShiftsServices(Ecolab3DDbContext ecolab3DDbContext)
        {
            this.ecolab3DDbContext = ecolab3DDbContext;
        }
        public async Task<IEnumerable<CorporateShifts>> GetAllAsync()
        {
            return await ecolab3DDbContext.CorporateShifts.ToListAsync();
        }

        
    }
}
