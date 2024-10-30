using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogiTrack.Infrastructure.SeedDb.Configurations
{
    public class IdentityRolesConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            var data = new SeedData();
            builder.HasData(new IdentityRole[] { data.LogisticsCompanyRole, data.ClientCompanyRole, data.AccountRole, data.SpeditorRole, data.DriverRole });
        }
    }
}
