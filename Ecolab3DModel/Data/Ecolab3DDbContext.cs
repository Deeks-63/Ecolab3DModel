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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CorporateShifts>(entity =>
            {
                entity.HasKey(e => new { e.CustomerKey, e.ShiftDayOfWeek, e.ShiftEnumeration })
                    .HasName("PK__Corporat__8650B5CCAB604E56");
                entity.ToTable("CorporateShifts", "CustomerPortal");
            });
            modelBuilder.Entity<CustomerGoal>(entity =>
            {
                entity.HasKey(e => e.CustomerKey)
                    .HasName("PK_CustomerGoals");
                entity.ToTable("CustomerGoal", "CustomerPortal");
            });
            modelBuilder.Entity<ServiceAreaShifts>(entity =>
            {
                entity.HasKey(e => new { e.AccountNumber, e.ServiceAreaId, e.CustomerKey, e.CdmsiteKey, e.ShiftDayOfWeek, e.ShiftEnumeration })
                    .HasName("PK__ServiceA__40FEF4584EBF5862");
                entity.ToTable("ServiceAreaShifts", "CustomerPortal");
            });
            modelBuilder.Entity<ShiftDomain>(entity =>
            {
                entity.HasKey(e => e.ShiftEnumeration)
                    .HasName("PK__ShiftDom__64BEA91604F43E5D");
                entity.ToTable("ShiftDomain", "CustomerPortal");
            });
        }
    }
}

