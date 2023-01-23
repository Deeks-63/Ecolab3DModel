using System.Data;
using Ecolab.Ecolab3D.Backend.FunctionApplication.Infrastructure.Persistence.EntityFrameworkModels;
using Ecolab3DModel.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NetTopologySuite.Index.HPRtree;

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

        public async Task<CorporateShifts> DeleteAsync(int Id)
        {
            var singleShift = await ecolab3DDbContext.CorporateShifts.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if(singleShift == null)
            {
                return null;
            }
            //Delete the shift
            //ecolab3DDbContext.CorporateShifts.Remove((CorporateShifts)singleShift);
            //ecolab3DDbContext.CorporateShifts.Where(x => x.Id == Id);
            //foreach(var singleShift in CorporateShiftsServices)
            //{
            //    if (row.IsNull("foo")) row["foo"] = "-";
            //    if (row.IsNull("bar")) row["bar"] = "-";
            //}
            singleShift.IsActive = false;
            await ecolab3DDbContext.SaveChangesAsync();
            return (CorporateShifts)singleShift;
        }

        public async Task<IEnumerable<CorporateShifts>> GetAllAsync()
        {
            return await ecolab3DDbContext.CorporateShifts.Where(x => x.IsActive == true).ToListAsync();
        }

        public async Task<IEnumerable<CorporateShifts>> GetAsync(int Id)
        {
            //return await ecolab3DDbContext.CorporateShifts.FirstOrDefaultAsync(x => x.CustomerKey == CustomerKey);
            return await ecolab3DDbContext.CorporateShifts.Where(x => x.Id == Id).ToListAsync();
        }

        public async Task<IEnumerable<CorporateShifts>> UpdateAsync(int Id, IEnumerable<CorporateShifts> corporateShifts)
        {
            var allShifts = await ecolab3DDbContext.CorporateShifts.ToListAsync();
            var allFilteredShifts = allShifts.Where(o =>
             corporateShifts.Where(x => x.Id == Id).Any()
            ).ToList();
            foreach (var existingCustomer in allFilteredShifts)
            {
                var input = corporateShifts.Where(x => x.Id == Id).FirstOrDefault();

                existingCustomer.ShiftDayOfWeek = input.ShiftDayOfWeek;
                existingCustomer.NumberOfWorkers = input.NumberOfWorkers;
                //existingCustomer.ShiftEnumeration= corporateShifts.ShiftEnumeration;
                existingCustomer.StartTime = input.StartTime;
                existingCustomer.EndTime = input.EndTime;
                existingCustomer.IsActive = input.IsActive;
                existingCustomer.CreatedDate = input.CreatedDate;
                existingCustomer.ShiftName = input.ShiftName;
                existingCustomer.LastModifiedDate = input.LastModifiedDate;
            }
            await ecolab3DDbContext.SaveChangesAsync();
            return null;
        }

        
    }
}
