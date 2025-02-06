using EfClass.Models.DBModels.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfClass.Services
{
    public  interface IUserService
    {
        public List<UserDto> GetUsers();
        public UserDto GetUser(int id);
        public UserDto GetUserByEmail(string email);
        public bool SaveNewUser(UserDto user);
    }
}
