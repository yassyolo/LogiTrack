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

            var data = new SeedData();
            builder.HasData(new CashRegister[] {data.CashRegister1, data.CashRegister2, data.CashRegister3 , data.CashRegister4 , data.CashRegister5 , data.CashRegister6 });
        }
    }
}
