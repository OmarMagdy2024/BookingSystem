using BookingSystem.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Repository.Data.Configurations
{
    public class HallConfig : IEntityTypeConfiguration<Hall>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Hall> builder)
        {
            builder.Property(H => H.Name).IsRequired();
            builder.Property(H => H.Capacity).IsRequired();
            builder.Property(H => H.price).IsRequired();
            builder.Property(H => H.Address).IsRequired();
            builder.HasMany(h => h.packages).WithOne();
            builder.Property(h => h.price)
                .HasColumnType("decimal(18,2)");
        }
    }
}
