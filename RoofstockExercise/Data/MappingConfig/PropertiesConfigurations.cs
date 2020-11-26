using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoofstockExercise.Models;

namespace RoofstockExercise.Data.MappingConfig
{
    public class PropertiesConfigurations : IEntityTypeConfiguration<PropertiesModel>
    {
        public void Configure(EntityTypeBuilder<PropertiesModel> builder)
        {
            builder.ToTable("Property");
            builder.HasKey(key => key.Id);
        }
    }
}
