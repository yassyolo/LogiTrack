using LogisticsSystem.Infrastructure.Data.DataModels;
using LogiTrack.Infrastructure.Data.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogiTrack.Infrastructure.SeedDb.Configurations
{
    public class InvoiceConnfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasOne(x => x.Delivery)
                .WithOne(x => x.Invoice)
                .HasForeignKey<Delivery>(x => x.InvoiceId)
                .OnDelete(DeleteBehavior.Restrict);

           builder.Ignore("ClientCompanyId1");

            var data = new SeedData();
            builder.HasData(new Invoice[] { data.Invoice1, data.Invoice2, data.Invoice3 });
        }
    }
}
