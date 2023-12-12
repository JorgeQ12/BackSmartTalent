using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackSmartTalent.Domain.Entities
{
    public class Reservations
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("Rooms")]
        public Guid IdRooms { get; set; }

        [ForeignKey("Guests")]
        public Guid IdGuests { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public int NumberPeople { get; set; } 
        public string CityDestination { get; set; } 
        public bool Enabled { get; set; }

        public virtual Rooms Rooms { get; set; }
        public virtual Guests Guests { get; set; }
    }
}
