using AutoMapper;
using DTOs.DTO;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models.Entities;
using Repository.UserRepository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _configuration = configuration;
        }
        public User GetUserById(int id)
        {
            return _userRepository.GetById(id);
        }
        public User GetUserByUsername(string username)
        {
            return _userRepository.GetByUserName(username);
        }

        public ResponseUserDto AddUser(CreateUserDto userDto, string adminUsername)
        {
            var adminUser = _userRepository.GetByUserName(adminUsername);
            if (adminUser == null || adminUser.Role != "Admin")
            {
                throw new UnauthorizedAccessException("Only admins can create users.");
            }
            var user = _mapper.Map<User>(userDto);
            user.Password = userDto.Password;
            //user.Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password);
            _userRepository.AddUser(user);
            return _mapper.Map<ResponseUserDto>(user);
        }

        public bool DeleteUser(string userName)
        {
            var user = _userRepository.GetByUserName(userName);
            if (user == null)
            {
                return false;
            }
            _userRepository.DeleteUser(user);
            return true;
        }
        public IEnumerable<ResponseUserDto> GetAll()
        {
            var users = _userRepository.GetAll();
            return _mapper.Map<List<ResponseUserDto>>(users);
        }
        public string Login(LoginDto loginDto)
        {
            var user = _userRepository.GetByUserName(loginDto.UserName);
            if (user == null || user.Password != loginDto.Password)
            {
                return null;
            }
            return GenerateJwtToken(user);
        }
        private string GenerateJwtToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Role, user.Role)
        };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(3),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
