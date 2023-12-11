using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackSmartTalent.Domain.Entities
{
    public class Reservas
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("Habitaciones")]
        public Guid IdHabitacion { get; set; }

        [ForeignKey("Huespedes")]
        public Guid IdHuespedes { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        public int CantidadPersonas { get; set; } 
        public string CiudadDestino { get; set; } 
        public bool Activo { get; set; }

        public virtual Habitaciones Habitaciones { get; set; }
        public virtual Huespedes Huespedes { get; set; }
    }
}
