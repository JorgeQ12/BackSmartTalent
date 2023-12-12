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
        public User GetLoginAdmin(UserDTO user)
        {
            try
            {
                return _context.User
                    .Where(x => x.Username.Equals(user.UsernameDTO) && 
                                x.Password.Equals(user.PasswordDTO) && x.Administrator).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        ///<summary>
        ///Login de Usuarios
        ///</summary>
        public User GetLoginUser(UserDTO user)
        {
            try
            {
                return _context.User
                    .Where(x => x.Username.Equals(user.UsernameDTO) &&
                                x.Username.Equals(user.UsernameDTO) && !x.Administrator).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
