using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackSmartTalent.Domain.Entities
{
    public class Hotels
    {
        [Key]
        public Guid Id { get; set; }
        public string Names { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public bool Enabled { get; set; }

        public virtual ICollection<Rooms> Rooms { get; set; }
    }
}
