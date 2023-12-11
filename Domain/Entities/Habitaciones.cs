using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackSmartTalent.Domain.Entities
{
    public class Habitaciones
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("Hoteles")]
        public Guid IdHotel { get; set; }
        public string TipoHabitacion { get; set; }
        public decimal CostoBase { get; set; }
        public decimal Impuestos { get; set; }
        public int CantidadPersonas { get; set; }
        public string Ubicacion { get; set; }
        public bool Activo { get; set; }

        public virtual Hoteles HotelesNavigation { get; set; }
        public virtual Reservas ReservasNavigation { get; set; }
    }
}
