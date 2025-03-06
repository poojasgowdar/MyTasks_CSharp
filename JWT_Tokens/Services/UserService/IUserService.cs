using DTOs.DTO;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UserService
{
    public interface IUserService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        User GetUserById(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginDto"></param>
        /// <returns></returns>
        string Login(LoginDto loginDto);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        User GetUserByUsername(string username);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userDto"></param>
        ResponseUserDto AddUser(CreateUserDto userDto, string adminUsername);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        bool DeleteUser(string userName);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<ResponseUserDto> GetAll();
        
    }
}
