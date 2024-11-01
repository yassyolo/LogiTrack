using Microsoft.EntityFrameworkCore;
using LogiTrack.Infrastructure.Data.DataModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LogisticsSystem.Infrastructure.Data.DataModels;

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

            builder.Property(x => x.DomesticPriceForNotSharedTruck)
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.DomesticPriceForSharedTruck)
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.InternationalPriceForSharedTruck)
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.InternationalPriceForNotSharedTruck)
                .HasColumnType("decimal(18,2)");

            var data = new SeedData();
            builder.HasData(new PricesPerSize[] { data.PricesPerSize1, data.PricesPerSize2 });
        }
    }
}
