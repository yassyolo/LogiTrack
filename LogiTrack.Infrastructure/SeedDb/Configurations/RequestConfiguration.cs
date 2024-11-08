using LogisticsSystem.Infrastructure.Data.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogiTrack.Infrastructure.SeedDb.Configurations
{
    public class RequestConfiguration : IEntityTypeConfiguration<Request>
    {
        public void Configure(EntityTypeBuilder<Request> builder)
        {
            builder.HasOne(x => x.ClientCompany)
                .WithMany(x => x.Requests)
                .HasForeignKey(x => x.ClientCompanyId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Offer)
                .WithOne(x => x.Request)
                .HasForeignKey<Offer>(x => x.RequestId) 
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.CalculatedPrice)
                 .HasColumnType("decimal(18,2)");

            builder.Property(x => x.ApproximatePrice)
                .HasColumnType("decimal(18,2)");

            builder.HasOne(x => x.PickupAddress)
                .WithOne()
                .HasForeignKey<Request>(x => x.PickupAddressId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.DeliveryAddress)
                .WithOne()
                .HasForeignKey<Request>(x => x.DeliveryAddressId)
                .OnDelete(DeleteBehavior.Restrict);


            var data = new SeedData();
            builder.HasData(new Request[] { data.Request1, data.Request2, data.Request3, data.Request4, data.Request5 });
        }
    }
}
