using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackSmartTalent.Domain.Entities
{
    public class Hoteles
    {
        [Key]
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Cuidad { get; set; }
        public string Direccion { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<Habitaciones> Habitaciones { get; set; }
    }
}
