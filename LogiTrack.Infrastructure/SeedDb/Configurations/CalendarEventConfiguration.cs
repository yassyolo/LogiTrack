using LogiTrack.Infrastructure.Data.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogiTrack.Infrastructure.SeedDb.Configurations
{
    public class CalendarEventConfiguration : IEntityTypeConfiguration<CalendarEvent>
    {
        public void Configure(EntityTypeBuilder<CalendarEvent> builder)
        {
            builder.HasOne(x => x.ClientCompany)
                .WithMany(x => x.CalendarEvents)
                .HasForeignKey(x => x.ClientCompanyId)
                .OnDelete(DeleteBehavior.Restrict);
            var data = new SeedData();
            builder.HasData(new CalendarEvent[] {data.CalendarEvent1, data.CalendarEvent2, data.CalendarEvent3});
        }
    }
}
