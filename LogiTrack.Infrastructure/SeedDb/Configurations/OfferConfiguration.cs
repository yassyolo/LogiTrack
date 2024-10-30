using LogisticsSystem.Infrastructure.Data.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogiTrack.Infrastructure.SeedDb.Configurations
{
    public class OfferConfiguration : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder.Property(x => x.FinalPrice)
               .HasColumnType("decimal(18,2)");

            builder.HasIndex(x => x.RequestId)
               .HasDatabaseName("IX_Offer_RequestId");

            builder.HasIndex(x => x.DeliveryId)
               .HasDatabaseName("IX_Offer_DeliveryId");

            /*var data = new SeedData();
            builder.HasData(new Offer[] { data.OfferForRequest1 });*/
        }
    }
}
