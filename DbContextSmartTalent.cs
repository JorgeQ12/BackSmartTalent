using BackSmartTalent.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackSmartTalent
{
    public class DbContextSmartTalent :DbContext
    {
        public DbSet<Rooms> Rooms { get; set; }
        public DbSet<Hotels> Hotels { get; set; }
        public DbSet<Guests> Guests { get; set; }
        public DbSet<Reservations> Reservations { get; set; }
        public DbSet<ContactEmergency> ContactEmergency { get; set; }
        public DbSet<User> User { get; set; }


        public DbContextSmartTalent(DbContextOptions<DbContextSmartTalent> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotels>()
                .HasMany(hotel => hotel.Rooms)
                .WithOne(habitacion => habitacion.HotelsNavigation)
                .HasForeignKey(habitacion => habitacion.IdHotels);
        }
    }
}
