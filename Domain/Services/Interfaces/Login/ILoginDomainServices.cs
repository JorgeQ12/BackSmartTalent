using BackSmartTalent.Domain.Entities;
using BackSmartTalent.DTOs;
using BackSmartTalent.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackSmartTalent.Domain.Services.Interfaces.Login
{
    public interface ILoginDomainServices
    {
        ///<summary>
        ///Login de Administradores
        ///</summary>
        Usuario GetLoginAdmin(UsuarioDTO usuario);

        ///<summary>
        ///Login de Usuario
        ///</summary>
        Usuario GetLoginUser(UsuarioDTO usuario);
    }
}
