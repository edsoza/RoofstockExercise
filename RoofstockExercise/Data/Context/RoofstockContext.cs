using Microsoft.EntityFrameworkCore;
using RoofstockExercise.Data.MappingConfig;

namespace RoofstockExercise.Data.Context
{
    public class RoofstockContext: DbContext, IRoofstockContext
    {
        public RoofstockContext(DbContextOptions<RoofstockContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PropertiesConfigurations());

            base.OnModelCreating(modelBuilder);
        }
    }
}
