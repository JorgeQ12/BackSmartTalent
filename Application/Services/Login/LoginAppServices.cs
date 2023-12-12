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
        public ResultResponse<User> GetLoginAdmin(UserDTO user)
        {
            try
            {
                //Valdacion de campos
                var validationErrors = _globalValidator.validateUser(user);
                if (validationErrors != null)
                {
                    return validationErrors;
                }

                User getUser = _loginDomainServices.GetLoginAdmin(user);
                if (getUser == null)
                {
                    return new ResultResponse<User>(false, GlobalResponses.LoginUsuarioNoEncontrado);
                }
                return new ResultResponse<User>(true, getUser);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        } 

        ///<summary>
        ///Login de Usuarios
        ///</summary>
        public ResultResponse<User> GetLoginUser(UserDTO user)
        {
            try
            {
                var validationErrors = _globalValidator.validateUser(user);
                if (validationErrors != null)
                {
                    return validationErrors;
                }

                User getUser = _loginDomainServices.GetLoginUser(user);
                if (getUser == null)
                {
                    return new ResultResponse<User>(false, GlobalResponses.LoginUsuarioNoEncontrado);
                }
                return new ResultResponse<User>(true, getUser);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

