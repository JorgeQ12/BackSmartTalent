using BackSmartTalent.Application.Services.Interfaces.Login;
using BackSmartTalent.Domain.Entities;
using BackSmartTalent.DTOs;
using BackSmartTalent.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackSmartTalent.Controllers.Login
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly ILoginAppServices _LoginAppServices;
        public LoginController(ILoginAppServices loginAppServices)
        {
            _LoginAppServices = loginAppServices;
        }

        ///<summary>
        ///Login de Administradores
        ///</summary>
        [HttpPost]
        [Route(nameof(LoginController.GetLoginAdmin))]
        public ResultResponse<User> GetLoginAdmin(UserDTO user) => _LoginAppServices.GetLoginAdmin(user);

        ///<summary>
        ///Login de Usuarios
        ///</summary>
        [HttpPost]
        [Route(nameof(LoginController.GetLoginUser))]
        public ResultResponse<User> GetLoginUser(UserDTO user) => _LoginAppServices.GetLoginUser(user);
    }
}
