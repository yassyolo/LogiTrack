using LogiTrack.Infrastructure.Data.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogiTrack.Infrastructure.SeedDb.Configurations
{
    public class DeliveryConfiguration : IEntityTypeConfiguration<Delivery>
    {
        public void Configure(EntityTypeBuilder<Delivery> builder)
        {
            builder.HasOne(x => x.Driver)
                .WithMany(x => x.Deliveries)
                .HasForeignKey(x => x.DriverId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Offer)
           .WithOne(x => x.Delivery)
           .HasForeignKey<Delivery>(x => x.OfferId) 
           .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Vehicle)
                .WithMany(x => x.Deliveries)
                .HasForeignKey(x => x.VehicleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.CashRegisters)
                .WithOne(x => x.Delivery)
                .HasForeignKey(x => x.DeliveryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.DeliveryTrackings)
                .WithOne(x => x.Delivery)
                .HasForeignKey(x => x.DeliveryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.TotalExpenses)
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.Profit)
                .HasColumnType("decimal(18,2)");

            builder.HasIndex(x => x.DriverId)
                .HasDatabaseName("IX_Delivery_DriverId");

            builder.HasIndex(x => x.VehicleId)
              .HasDatabaseName("IX_Delivery_VehicleId");

            var data = new SeedData();
            builder.HasData(new Delivery[] { data.DeliveryForOfferForRequest1 });
        }
    }
}
