using LogisticsSystem.Infrastructure.Data.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogiTrack.Infrastructure.SeedDb.Configurations
{
    public class ClientCompanyConfiguration : IEntityTypeConfiguration<ClientCompany>
    {
        public void Configure(EntityTypeBuilder<ClientCompany> builder)
        {
            builder.HasOne(x => x.User)
                .WithOne()
                .HasForeignKey<ClientCompany>(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Requests)
                .WithOne(x => x.ClientCompany)
                .HasForeignKey(x => x.ClientCompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Offers)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Invoices)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);

            var data = new SeedData();
            builder.HasData(new ClientCompany[] { data.ClientCompany1, data.ClientCompany2 });
        }
    }
}
