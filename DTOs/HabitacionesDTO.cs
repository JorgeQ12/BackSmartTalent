using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackSmartTalent.DTOs
{
    public class HabitacionesDTO
    {
        public Guid IdHotelDTO { get; set; }
        public string TipoHabitacionDTO { get; set; }
        public decimal CostoBaseDTO { get; set; }
        public decimal ImpuestosDTO { get; set; }
        public int CantidadPersonasDTO { get; set; }
        public string UbicacionDTO { get; set; }
    }

    public class HabitacionesUpdateDTO
    {
        public Guid IdHabitacionDTO { get; set; }
        public Guid IdHotelDTO { get; set; }
        public string TipoHabitacionDTO { get; set; }
        public decimal CostoBaseDTO { get; set; }
        public decimal ImpuestosDTO { get; set; }
        public int CantidadPersonasDTO { get; set; }
        public string UbicacionDTO { get; set; }
        public bool ActivoDTO { get; set; }

    }
}
