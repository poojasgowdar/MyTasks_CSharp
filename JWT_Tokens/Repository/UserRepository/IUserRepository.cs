using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UserRepository
{
    public interface IUserRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        User GetById(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        User GetByUserName(string UserName);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        void AddUser(User user);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        void DeleteUser(User user);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<User> GetAll();

    }
}
