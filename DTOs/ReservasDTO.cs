using BackSmartTalent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackSmartTalent.DTOs
{
    public class ReservasDTO
    {
        public string NombreHotelDTO { get; set; }
        public string DireccionHotelDTO { get; set; }
        public string TipoHabitacionDTO { get; set; }
        public decimal CostoBaseDTO { get; set; }
        public decimal ImpuestosDTO { get; set; }
        public string UbicacionHabitacionDTO { get; set; }
        public DateTime FechaEntradaDTO { get; set; }
        public DateTime FechaSalidaDTO { get; set; }
        public int CantidadPersonasDTO { get; set; }
        public string CiudadDestinoDTO { get; set; }
        public bool ActivoDTO { get; set; }
    }

    public class InsertBookingDTO
    {
        public Guid IdHabitacionDTO { get; set; }
        public HuespedesDTO HuespedesDTO { get; set; }
        public DateTime FechaEntradaDTO { get; set; }
        public DateTime FechaSalidaDTO { get; set; }
        public int CantidadPersonasDTO { get; set; }
        public string CiudadDestinoDTO { get; set; }
        public bool ActivoDTO { get; set; }
    }
}
