using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackSmartTalent.Domain.Entities
{
    public class ContactoEmergencia
    {
        [Key]
        public Guid Id { get; set; }
        public string NombresCompletos { get; set; }
        public string Telefono { get; set; } 
    }
}
