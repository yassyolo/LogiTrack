using LogisticsSystem.Infrastructure.Data.DataModels;
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
                .HasForeignKey<Invoice>(x => x.Id)
                .OnDelete(DeleteBehavior.Restrict);

           builder.Ignore("ClientCompanyId");

            /*var data = new SeedData();
            builder.HasData(new Invoice[] { data.InvoiceForOfferForRequest1 });*/
        }
    }
}
