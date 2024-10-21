﻿using LogiTrack.Infrastructure.Data.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogiTrack.Infrastructure.SeedDb.Configurations
{
    public class FuelPriceConfiguration : IEntityTypeConfiguration<FuelPrice>
    {
        public void Configure(EntityTypeBuilder<FuelPrice> builder)
        {
            builder.Property(x => x.Price)
               .HasColumnType("decimal(18,2)");
        }
    }
}