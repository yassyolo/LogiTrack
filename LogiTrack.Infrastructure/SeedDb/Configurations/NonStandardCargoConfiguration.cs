using LogiTrack.Infrastructure.Data.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogiTrack.Infrastructure.SeedDb.Configurations
{
    public class NonStandardCargoConfiguration : IEntityTypeConfiguration<NonStandardCargo>
    {
        public void Configure(EntityTypeBuilder<NonStandardCargo> builder)
        {
            builder.HasOne(x => x.Request)
                .WithMany(x => x.NonStandardCargos)
                .HasForeignKey(x => x.RequestId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
