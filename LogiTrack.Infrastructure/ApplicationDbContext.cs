using LogisticsSystem.Infrastructure.Data.DataModels;
using LogiTrack.Infrastructure.Data.DataModels;
using LogiTrack.Infrastructure.SeedDb.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LogiTrack.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new IdentityUserConfiguration());
            builder.ApplyConfiguration(new IdentityRolesConfiguration());
            builder.ApplyConfiguration(new IdentityUserRolesConfiguration());
            builder.ApplyConfiguration(new CashRegisterConfiguration());
            builder.ApplyConfiguration(new ClientCompanyConfiguration());
            builder.ApplyConfiguration(new DeliveryConfiguration());
            builder.ApplyConfiguration(new DeliveryTrackingConfiguration());
            builder.ApplyConfiguration(new DriverConfiguration());
            builder.ApplyConfiguration(new InvoiceConnfiguration());
            builder.ApplyConfiguration(new OfferConfiguration());
            builder.ApplyConfiguration(new RequestConfiguration());
            builder.ApplyConfiguration(new VehicleConfiguration());
            builder.ApplyConfiguration(new PricesPerSizeConfiguration());

            base.OnModelCreating(builder);
        }

        public DbSet<CashRegister> CashRegisters { get; set; }
        public DbSet<ClientCompany> ClientCompanies { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<DeliveryTracking> DeliveryTrackings { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<PricesPerSize> PricesPerSize { get; set;}
    }
}
