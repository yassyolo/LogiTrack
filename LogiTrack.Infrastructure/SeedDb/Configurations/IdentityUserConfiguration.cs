using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogiTrack.Infrastructure.SeedDb.Configurations
{
    public class IdentityUserConfiguration : IEntityTypeConfiguration<IdentityUser>
    {
        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {
           var data = new SeedData();
            builder.HasData(new IdentityUser[] { data.LogiticsCompanyUser, data.ClientCompany1User, data.SecretaryUser, data.SpeditorUser });
        }
    }
}
