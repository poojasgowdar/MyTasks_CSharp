using AutoMapper;
using MiniOffice365Backend.DataAccess.DBModel;
using MiniOffice365Backend.DataAccess.Repositories;
using MiniOffice365Backend.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniOffice365Backend.Manager
{
    public class UserManager:IUserManager
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserManager(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDTO> GetUserByEmailAsync(string email)
        {
            var user = _userRepository.GetUserByEmail(email);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<bool> RegisterUserAsync(RegisterRequest request)
        {
            var existingUser = _userRepository.GetUserByEmail(request.Email);
            if (existingUser != null) return false;

            var newUser = new User
            {
                UserName = request.UserName,
                Email = request.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Role = "User"
            };

            _userRepository.AddUser(newUser);
            return true;
        }

        public async Task<List<UserDTO>> GetAllUsersAsync()
        {
            var users = _userRepository.GetAllUsers();
            return _mapper.Map<List<UserDTO>>(users);
        }

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            var user = _userRepository.GetUserById(id);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<bool> UpdateUserAsync(int id, UserDTO userDTO)
        {
            var user = _userRepository.GetUserById(id);
            if (user == null) return false;

            user.UserName = userDTO.UserName;
            user.Email = userDTO.Email;
            user.Role = userDTO.Role;

            _userRepository.UpdateUser(user);
            return true;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = _userRepository.GetUserById(id);
            if (user == null) return false;

            _userRepository.DeleteUser(id);
            return true;
        }
    }
}
