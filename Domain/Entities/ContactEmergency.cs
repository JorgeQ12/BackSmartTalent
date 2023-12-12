using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackSmartTalent.Domain.Entities
{
    public class ContactEmergency
    {
        [Key]
        public Guid Id { get; set; }
        public string NameslastNames { get; set; }
        public string Phone { get; set; } 
    }
}
