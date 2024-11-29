using LogiTrack.Infrastructure.Data.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogiTrack.Infrastructure.SeedDb.Configurations
{
    public class ReservedForDeliveryConfiguration : IEntityTypeConfiguration<ReservedForDelivery>
    {
        public void Configure(EntityTypeBuilder<ReservedForDelivery> builder)
        {
            builder.HasOne(x => x.Request)
                .WithOne()
                .HasForeignKey<ReservedForDelivery>(x => x.RequestId);

            builder.HasOne(x => x.Vehicle)
                .WithOne()
                .HasForeignKey<ReservedForDelivery>(x => x.VehicleId);

            builder.HasOne(x => x.Driver)
                .WithOne()
                .HasForeignKey<ReservedForDelivery>(x => x.DriverId);
        }
    }
}
