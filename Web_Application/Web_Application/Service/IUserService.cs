using Web_Application.Models;
using Web_Application.ViewModels;

namespace Web_Application.Service
{
    public interface IUserService
    {
        public string Login(UserLoginDto loginDto);
        public ResponseUserDto Add(CreateUserDto userDto);
        public User GetUserById(int id);
        public void Delete(string user);
        public User GetUserByUsername(string username);
        //public IEnumerable<User> GetAll();
        public IEnumerable<ResponseUserDto> GetAll();

    }
}
