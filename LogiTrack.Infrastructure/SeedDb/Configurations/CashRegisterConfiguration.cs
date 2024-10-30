using LogiTrack.Infrastructure.Data.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogiTrack.Infrastructure.SeedDb.Configurations
{
    public class CashRegisterConfiguration : IEntityTypeConfiguration<CashRegister>
    {
        public void Configure(EntityTypeBuilder<CashRegister> builder)
        {
            builder.HasOne(x => x.Delivery)
                .WithMany(x => x.CashRegisters)
                .HasForeignKey(x => x.DeliveryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Amount)
              .HasColumnType("decimal(18,2)");

            /*var data = new SeedData();
            builder.HasData(new CashRegister[] {data.CashRegisterForDriver1, data.CashRegisterForVehicle1});*/
        }
    }
}
