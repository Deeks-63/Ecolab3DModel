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

        public async Task<IEnumerable<CorporateShifts>> GetAsync(int CustomerKey)
        {
            //return await ecolab3DDbContext.CorporateShifts.FirstOrDefaultAsync(x => x.CustomerKey == CustomerKey);
            return await ecolab3DDbContext.CorporateShifts.Where(x => x.CustomerKey == CustomerKey).ToListAsync();
        }

        public async Task<CorporateShifts> UpdateAsync(int CustomerKey, CorporateShifts corporateShifts)
        {
           var existingCustomer = await ecolab3DDbContext.CorporateShifts.FirstOrDefaultAsync(x => x.CustomerKey == CustomerKey 
           && x.ShiftEnumeration == corporateShifts.ShiftEnumeration
           && x.ShiftDayOfWeek == corporateShifts.ShiftDayOfWeek);
            if(existingCustomer == null)
            {
                return null;
            }
            //existingCustomer.ShiftDayOfWeek = corporateShifts.ShiftDayOfWeek;
            existingCustomer.NumberOfWorkers = corporateShifts.NumberOfWorkers;
            //existingCustomer.ShiftEnumeration= corporateShifts.ShiftEnumeration;
            existingCustomer.StartTime= corporateShifts.StartTime;
            existingCustomer.EndTime= corporateShifts.EndTime;
            existingCustomer.IsActive = corporateShifts.IsActive;
            existingCustomer.CreatedDate= corporateShifts.CreatedDate;
            existingCustomer.ShiftName= corporateShifts.ShiftName;
            existingCustomer.LastModifiedDate= corporateShifts.LastModifiedDate;

            await ecolab3DDbContext.SaveChangesAsync();
            return existingCustomer;
        }
    }
}
