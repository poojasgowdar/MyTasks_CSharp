using MiniOffice365Backend.DataAccess.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniOffice365Backend.DataAccess.Repositories
{
    public interface IUserRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        User GetUserByEmail(string email);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        void AddUser(User user);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<User> GetAllUsers();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        User GetUserById(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        void UpdateUser(User user);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void DeleteUser(int id);
    }
}
