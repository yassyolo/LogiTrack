using LogiTrack.Infrastructure.Data.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogiTrack.Infrastructure.SeedDb.Configurations
{
    public class StandartCargoConfiguration : IEntityTypeConfiguration<StandartCargo>
    {
        public void Configure(EntityTypeBuilder<StandartCargo> builder)
        {
            builder.HasOne(x => x.Request)
                .WithOne(x => x.StandartCargo)
                .HasForeignKey<StandartCargo>(x => x.RequestId)
                .OnDelete(DeleteBehavior.Restrict);
            var data = new SeedData();
            builder.HasData(new StandartCargo[] { data.StandartCargo1, data.StandartCargo2, data.StandartCargo3 });
        }
    }

}
