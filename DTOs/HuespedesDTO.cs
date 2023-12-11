using BackSmartTalent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackSmartTalent.DTOs
{
    public class HuespedesDTO
    {
        public string NombresDTO { get; set; }
        public string ApellidosDTO { get; set; }
        public DateTime FechaNacimientoDTO { get; set; }
        public string GeneroDTO { get; set; }
        public string TipoDocumentoDTO { get; set; }
        public string NumeroDocumentoDTO { get; set; }
        public string EmailDTO { get; set; }
        public string TelefonoDTO { get; set; }
        public ContactoEmergenciaDTO ContactoEmergencia { get; set; }
    }
}
