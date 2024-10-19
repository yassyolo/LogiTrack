using LogiTrack.Infrastructure.Data.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogiTrack.Infrastructure.SeedDb.Configurations
{
    public class DeliveryTrackingConfiguration : IEntityTypeConfiguration<DeliveryTracking>
    {
        public void Configure(EntityTypeBuilder<DeliveryTracking> builder)
        {
            builder.HasOne(x => x.Delivery)
                 .WithMany(x => x.DeliveryTrackings)
                .HasForeignKey(x => x.DeliveryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Driver)
                .WithMany()
                .HasForeignKey(x => x.DriverId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
