using Ecolab.Ecolab3D.Backend.FunctionApplication.Infrastructure.Persistence.EntityFrameworkModels;
using Microsoft.EntityFrameworkCore;

namespace Ecolab3DModel.Data
{
    public class Ecolab3DDbContext : DbContext
    {
        //Constructor
        public Ecolab3DDbContext(DbContextOptions<Ecolab3DDbContext>options) : base(options)
        {

        }

        //Creating DbSet. By creating this we are telling entity framework that
        //please create a stable shift and goals for us if it doesn't exist in database
        public DbSet<CorporateShifts> CorporateShifts { get;set; }
        public DbSet<CustomerGoal> customerGoals { get;set; }
        public DbSet<ServiceAreaShifts> serviceAreasShifts { get;set;}
        public DbSet<ShiftDomain> shiftDomains { get;set; }  
    }
}
