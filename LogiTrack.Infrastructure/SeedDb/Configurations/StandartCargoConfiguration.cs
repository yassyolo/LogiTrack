using LogiTrack.Infrastructure.Data.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogiTrack.Infrastructure.SeedDb.Configurations
{
    public class StandartCargoConfiguration : IEntityTypeConfiguration<StandartCargo>
    {
        public void Configure(EntityTypeBuilder<StandartCargo> builder)
        {            
            var data = new SeedData();
            builder.HasData(new StandartCargo[] { data.StandartCargo1, data.StandartCargo2, data.StandartCargo3 });
        }
    }

}
