using LogisticsSystem.Infrastructure.Data.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogiTrack.Infrastructure.SeedDb.Configurations
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasMany(v => v.Deliveries)
                .WithOne(d => d.Vehicle)
                .HasForeignKey(d => d.VehicleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.ContantsExpenses)
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.PurchasePrice)
                .HasColumnType("decimal(18,2)");

            var data = new SeedData();
            builder.HasData(new Vehicle[] { data.Vehicle1ForDelivery, data.Vehicle2 });
        }
    }
}
