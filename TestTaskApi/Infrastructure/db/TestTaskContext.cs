using Microsoft.EntityFrameworkCore;
using TestTaskApi.Entities;

namespace TestTaskApi.Infrastructure.db
{
    public class TestTaskContext: DbContext
    {
        public DbSet<Patient> Patients { get; set; }

        public TestTaskContext(DbContextOptions<TestTaskContext> options)
            : base(options) 
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().OwnsOne(p => p.Name);
        }
    }
}
