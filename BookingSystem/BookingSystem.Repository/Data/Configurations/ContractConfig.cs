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
    public class ContractConfig : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.Property(C => C.bookingid)
            .IsRequired();

            builder.Property(C=>C.BrideName) .IsRequired();

            builder.Property(C=>C.GroomName) .IsRequired();

            builder.Property(C => C.Amount)
                .HasColumnType("decimal (18,2)");
                
                

                
        }
    }
}
