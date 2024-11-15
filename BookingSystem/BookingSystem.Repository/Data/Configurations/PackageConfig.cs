using BookingSystem.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Repository.Data.Configurations
{
    public class PackageConfig : IEntityTypeConfiguration<Package>
    {
        public void Configure(EntityTypeBuilder<Package> builder)
        {
             builder.Property(P=>P.Name) .IsRequired() 
                .HasMaxLength(256);
            builder.Property(P => P.Description);
            builder.Property(P => P.Price).IsRequired();
        }
    }
}
