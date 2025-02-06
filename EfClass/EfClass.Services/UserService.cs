using EfClass.Managers;
using EfClass.Models.DBModels.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfClass.Services
{
    public class UserService : IUserService
    {

        private IUsersManager _usersManager;
        public UserService(IUsersManager usersManager)
        {
            _usersManager = usersManager;
        }
        public UserDto GetUser(int id)
        {
            return _usersManager.GetUser(id);
        }

        public UserDto GetUserByEmail(string email)
        {
            return _usersManager.GetUserByEmail(email);
        }

        public List<UserDto> GetUsers()
        {
            return _usersManager.GetUsers();
        }

        public bool SaveNewUser(UserDto user)
        {
            return _usersManager.SaveNewUser(user);
        }
    }
}
