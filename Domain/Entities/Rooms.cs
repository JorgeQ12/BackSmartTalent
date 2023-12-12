using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackSmartTalent.Domain.Entities
{
    public class Rooms
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("Hotels")]
        public Guid IdHotels { get; set; }
        public string TypeRoom { get; set; }
        public decimal CostBase { get; set; }
        public decimal Taxes { get; set; }
        public int NumberPeople { get; set; }
        public string Location { get; set; }
        public bool Enabled { get; set; }

        public virtual Hotels HotelsNavigation { get; set; }
        public virtual Reservations ReservationsNavigation { get; set; }
    }
}
