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
    public class BookingConfig : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.Property(B => B.CustomerName).IsRequired();
            builder.Property(B => B.NationalId)
                .IsRequired();




            builder.HasOne(b => b.hall)
                .WithMany()
                .HasForeignKey(h => h.hallId);


        }
    }
}
