using Ecolab.Ecolab3D.Backend.FunctionApplication.Infrastructure.Persistence.EntityFrameworkModels;
using Ecolab3DModel.Data;
using Microsoft.EntityFrameworkCore;

namespace Ecolab3DModel.Repositories
{
    public class CustomerGoalRepository : ICustomerGoalRepository
    {
        private readonly Ecolab3DDbContext ecolab3DDbContext;

        public CustomerGoalRepository(Ecolab3DDbContext ecolab3DDbContext)
        {
            this.ecolab3DDbContext = ecolab3DDbContext;
        }
        public async Task<IEnumerable<CustomerGoal>> GetAllAsync()
        {
            return await ecolab3DDbContext.customerGoals.ToListAsync();
        }

        public async Task<CustomerGoal> UpdateAsync(int id, CustomerGoal customerGoal)
        {
            var existingCustomer = await ecolab3DDbContext.customerGoals.FindAsync(id);
            if (existingCustomer != null)
            {
                existingCustomer.SinkSurfaceCompleted = customerGoal.SinkSurfaceCompleted;
                existingCustomer.LastModifiedDate = customerGoal.LastModifiedDate;
                existingCustomer.CreatedDate = customerGoal.CreatedDate;
                existingCustomer.CustomerName = customerGoal.CustomerName;
                existingCustomer.CustomerKey = customerGoal.CustomerKey;
                existingCustomer.PercentGoodRacks = customerGoal.PercentGoodRacks;
                existingCustomer.IsActive = customerGoal.IsActive;
                existingCustomer.HandWashes = customerGoal.HandWashes;
                await ecolab3DDbContext.SaveChangesAsync();
                return existingCustomer;
            }
            return null;
        }
    }
}
