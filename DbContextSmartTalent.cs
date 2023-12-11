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
        public DbSet<Habitaciones> Habitaciones { get; set; }
        public DbSet<Hoteles> Hoteles { get; set; }
        public DbSet<Huespedes> Huespedes { get; set; }
        public DbSet<Reservas> Reservas { get; set; }
        public DbSet<ContactoEmergencia> ContactoEmergencia { get; set; }
        public DbSet<Usuario> Usuario { get; set; }


        public DbContextSmartTalent(DbContextOptions<DbContextSmartTalent> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hoteles>()
                .HasMany(hotel => hotel.Habitaciones)
                .WithOne(habitacion => habitacion.HotelesNavigation)
                .HasForeignKey(habitacion => habitacion.IdHotel);
        }
    }
}
