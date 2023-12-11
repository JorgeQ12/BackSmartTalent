using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackSmartTalent.Domain.Entities
{
    public class Usuario
    {
        [Key]
        public Guid Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public bool Administrador { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
