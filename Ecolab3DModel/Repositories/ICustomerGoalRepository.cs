using Ecolab.Ecolab3D.Backend.FunctionApplication.Infrastructure.Persistence.EntityFrameworkModels;

namespace Ecolab3DModel.Repositories
{
    public interface ICustomerGoalRepository
    {
        Task<IEnumerable<CustomerGoal>> GetAllAsync();
        Task <CustomerGoal> UpdateAsync(int id, CustomerGoal customerGoal);
    }
}
