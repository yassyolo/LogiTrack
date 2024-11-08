using LogiTrack.Infrastructure.Data.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogiTrack.Infrastructure.SeedDb.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            var data = new SeedData();
            builder.HasData(new Address[] { data.Address1, data.Address2, data.Address3, data.Address4, data.Address5, data.Address6, data.Address7, data.Address8, data.Address9, data.Address10, data.Address11, data.Address12});
        }
    }
}
