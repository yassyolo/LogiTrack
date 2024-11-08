using LogiTrack.Infrastructure.Data.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogiTrack.Infrastructure.SeedDb.Configurations
{
    public class RatingConfiguration : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.HasOne(x => x.Delivery)
                .WithOne()
                .HasForeignKey<Rating>(x => x.DeliveryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
