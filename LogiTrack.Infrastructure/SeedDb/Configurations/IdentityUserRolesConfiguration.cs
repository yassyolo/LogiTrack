using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogiTrack.Infrastructure.SeedDb.Configurations
{
    public class IdentityUserRolesConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            var seedData = new SeedData();
            builder.HasData(new IdentityUserRole<string>[] { seedData.LogisticsCompanyUserRole, seedData.ClientCompanyUserRole, seedData.AccountantUserRole, seedData.SpeditorUserRole, seedData.DriverUserRole });
        }
    }
}
