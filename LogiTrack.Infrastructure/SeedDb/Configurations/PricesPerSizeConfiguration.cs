using Microsoft.EntityFrameworkCore;
using LogiTrack.Infrastructure.Data.DataModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogiTrack.Infrastructure.SeedDb.Configurations
{
    public class PricesPerSizeConfiguration : IEntityTypeConfiguration<PricesPerSize>
    {
        public void Configure(EntityTypeBuilder<PricesPerSize> builder)
        {
            builder.HasOne(x => x.Vehicle)
                   .WithOne()
                   .HasForeignKey<PricesPerSize>(x => x.VehicleId)
                   .OnDelete(DeleteBehavior.Restrict);

            var data = new SeedData();
            builder.HasData(new PricesPerSize[] { data.PricesPerSize1, data.PricesPerSize2 });
        }
    }
}
