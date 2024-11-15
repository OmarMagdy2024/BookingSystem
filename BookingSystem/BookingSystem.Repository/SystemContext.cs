using BookingSystem.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Repository
{
    public class SystemContext : DbContext
    {
        public SystemContext(DbContextOptions<SystemContext> options):base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               
                string server = Environment.MachineName == "MY_MACHINE" ? "Server1" : "Server2";
                string connectionString = $"Server={server};Database=OnlineMenuDB;Trusted_Connection=True;";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());


        }

        public DbSet<Package> Packages { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Contract> Contracts { get; set; }

    }

}
