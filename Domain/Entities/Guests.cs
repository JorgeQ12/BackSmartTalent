using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackSmartTalent.Domain.Entities
{
    public class Guests
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("ContactEmergency")]
        public Guid IdContactEmergency { get; set; }
        public string Names { get; set; }
        public string Surnames { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public virtual ContactEmergency ContactEmergency { get; set; }
    }
}
