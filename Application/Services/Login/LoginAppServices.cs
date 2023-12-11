using BackSmartTalent.Application.Services.Interfaces.Login;
using BackSmartTalent.Domain.Entities;
using BackSmartTalent.Domain.Services.Interfaces.Login;
using BackSmartTalent.DTOs;
using BackSmartTalent.Resources;
using BackSmartTalent.Utilities;
using BackSmartTalent.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackSmartTalent.Application.Services.Login
{
    public class LoginAppServices : ILoginAppServices
    {
        private readonly ILoginDomainServices _loginDomainServices;
        private readonly GlobalValidator _globalValidator;

        public LoginAppServices(ILoginDomainServices loginDomainServices, GlobalValidator globalValidator)
        {
            _loginDomainServices = loginDomainServices;
            _globalValidator = globalValidator;
        }


        ///<summary>
        ///Login de administradores
        ///</summary>
        public ResultResponse<Usuario> GetLoginAdmin(UsuarioDTO usuario)
        {
            try
            {
                //Valdacion de campos
                var validationErrors = _globalValidator.validateUser(usuario);
                if (validationErrors != null)
                {
                    return validationErrors;
                }

                Usuario getUser = _loginDomainServices.GetLoginAdmin(usuario);
                if (getUser == null)
                {
                    return new ResultResponse<Usuario>(false, RespuestasGlobales.LoginUsuarioNoEncontrado);
                }
                return new ResultResponse<Usuario>(true, getUser);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        } 

        ///<summary>
        ///Login de Usuarios
        ///</summary>
        public ResultResponse<Usuario> GetLoginUser(UsuarioDTO usuario)
        {
            try
            {
                var validationErrors = _globalValidator.validateUser(usuario);
                if (validationErrors != null)
                {
                    return validationErrors;
                }

                Usuario getUser = _loginDomainServices.GetLoginUser(usuario);
                if (getUser == null)
                {
                    return new ResultResponse<Usuario>(false, RespuestasGlobales.LoginUsuarioNoEncontrado);
                }
                return new ResultResponse<Usuario>(true, getUser);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

