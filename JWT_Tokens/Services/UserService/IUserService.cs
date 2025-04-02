using DTOs.DTO;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UserService
{
    public interface IUserService
    {
        /// <summary>
        /// Fetches an User by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        User GetUserById(int id);
        /// <summary>
        /// Anonymous Login 
        /// </summary>
        /// <param name="loginDto"></param>
        /// <returns></returns>
        string Login(LoginDto loginDto);
        /// <summary>
        /// Fetches an User by UserName
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        User GetUserByUsername(string username);
        /// <summary>
        /// Create an new User
        /// </summary>
        /// <param name="userDto"></param>
        ResponseUserDto AddUser(CreateUserDto userDto, string adminUsername);
        /// <summary>
        /// Deletes an User
        /// </summary>
        /// <param name="userName"></param>
        bool DeleteUser(string userName);
        /// <summary>
        /// Fetches all Users
        /// </summary>
        /// <returns></returns>
        IEnumerable<ResponseUserDto> GetAll();
        
    }
}

