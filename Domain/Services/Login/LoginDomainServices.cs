using BackSmartTalent.Domain.Entities;
using BackSmartTalent.Domain.Services.Interfaces.Login;
using BackSmartTalent.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackSmartTalent.Domain.Services.Login
{
    public class LoginDomainServices : ILoginDomainServices
    {
        private readonly DbContextSmartTalent _context;
        public LoginDomainServices(DbContextSmartTalent context)
        {
            _context = context;
        }

        ///<summary>
        ///Login de Administradores
        ///</summary>
        public Usuario GetLoginAdmin(UsuarioDTO usuario)
        {
            try
            {
                return _context.Usuario
                    .Where(x => x.NombreUsuario.Equals(usuario.NombreUsuarioDTO) && 
                                x.Contraseña.Equals(usuario.ContraseñaDTO) && x.Administrador).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        ///<summary>
        ///Login de Usuarios
        ///</summary>
        public Usuario GetLoginUser(UsuarioDTO usuario)
        {
            try
            {
                return _context.Usuario
                    .Where(x => x.NombreUsuario.Equals(usuario.NombreUsuarioDTO) &&
                                x.Contraseña.Equals(usuario.ContraseñaDTO) && !x.Administrador).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
