﻿using LogisticsSystem.Infrastructure.Data.DataModels;
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
            builder.ApplyConfiguration(new FuelPriceConfiguration());
            builder.ApplyConfiguration(new CalendarEventConfiguration());

            base.OnModelCreating(builder);
        }

        public DbSet<CashRegister> CashRegisters { get; set; } = null!;
        public DbSet<ClientCompany> ClientCompanies { get; set; } = null!;
        public DbSet<Request> Requests { get; set; } = null!;
        public DbSet<Offer> Offers { get; set; } = null!;
        public DbSet<Vehicle> Vehicles { get; set; } = null!;
        public DbSet<Driver> Drivers { get; set; } = null!;
        public DbSet<Delivery> Deliveries { get; set; } = null!;
        public DbSet<DeliveryTracking> DeliveryTrackings { get; set; } = null!;
        public DbSet<Invoice> Invoices { get; set; } = null!;
        public DbSet<PricesPerSize> PricesPerSize { get; set; } = null!;
        public DbSet<FuelPrice> FuelPrices { get; set; } = null!;
        public DbSet<CalendarEvent> CalendarEvents { get; set; } = null!;
    }
}
