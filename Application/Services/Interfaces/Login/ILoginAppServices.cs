using BackSmartTalent.Domain.Entities;
using BackSmartTalent.DTOs;
using BackSmartTalent.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackSmartTalent.Application.Services.Interfaces.Login
{
    public interface ILoginAppServices
    {
        ///<summary>
        ///Login de Administradores
        ///</summary>
        ResultResponse<Usuario> GetLoginAdmin(UsuarioDTO usuario);

        ///<summary>
        ///Login de Usuarios
        ///</summary>
        ResultResponse<Usuario> GetLoginUser(UsuarioDTO usuario);

    }
}
