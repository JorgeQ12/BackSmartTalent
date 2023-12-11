using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackSmartTalent.DTOs
{
    public class HotelesDTO
    {
        public string NombreDTO { get; set; }
        public string DireccionDTO { get; set; }
        public string CuidadDTO { get; set; }

    }

    public class HotelesUpdateDTO
    {
        public Guid IdHotelDTO { get; set; }
        public string NombreDTO { get; set; }
        public string DireccionDTO { get; set; }
        public string CuidadDTO { get; set; }
        public bool ActivoDTO { get; set; }
    }

    public class HotelesByCondition
    {
        public string NombreHotelDTO { get; set; }
        public string DireccionHotelDTO { get; set; }
        public string TipoHabitacionDTO { get; set; }
        public decimal CostoBaseDTO { get; set; }
        public decimal ImpuestosDTO { get; set; }
        public int CantidadPersonasDTO { get; set; }

    }
}
