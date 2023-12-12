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
        ResultResponse<User> GetLoginAdmin(UserDTO user);

        ///<summary>
        ///Login de Usuarios
        ///</summary>
        ResultResponse<User> GetLoginUser(UserDTO user);

    }
}
