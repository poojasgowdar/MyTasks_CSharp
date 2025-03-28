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
        /// Fetches by User Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        User GetById(int id);
        /// <summary>
        /// Fetches by User name
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        User GetByUserName(string UserName);
        /// <summary>
        /// Creates an New User
        /// </summary>
        /// <param name="user"></param>
        void AddUser(User user);
        /// <summary>
        /// Delets an Existing User
        /// </summary>
        /// <param name="user"></param>
        void DeleteUser(User user);
        /// <summary>
        /// Fetches all the Users
        /// </summary>
        /// <returns></returns>
        IEnumerable<User> GetAll();

    }
}
