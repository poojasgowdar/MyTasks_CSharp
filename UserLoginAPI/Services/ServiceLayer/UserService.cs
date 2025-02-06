using AutoMapper;
using DataAccessLayer.Models;
using Interfaces.Interface;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models.Dtos;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServiceLayer
{
    public class UserService : IService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;

        public UserService(IRepository<User> userRepository, IConfiguration configuration, IMapper mapper, IMemoryCache memoryCache)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }

        public ResponseUserDto Add(CreateUserDto userDto)
        {
            try
            {
                var user = _mapper.Map<User>(userDto);
                _userRepository.Add(user);
                return _mapper.Map<ResponseUserDto>(userDto);
            }
            catch (Exception ex)
            {

            }
            return new ResponseUserDto();
            //_userRepository.SaveChanges();
            //return user;
        }

        public void Delete(string username)
        {
            var user = _userRepository.GetByUserName(username);
            _userRepository.Delete(user);
            //_userRepository.SaveChanges();
        }
        public IEnumerable<ResponseUserDto> GetAll()
        {
            //var users = _userRepository.GetAll();
            //return _mapper.Map<List<ResponseUserDto>>(users);
          
            string cacheKey = "all_users";


            if (!_memoryCache.TryGetValue(cacheKey, out List<ResponseUserDto> users))
            {
                
                var userEntities = _userRepository.GetAll();

                
                users = _mapper.Map<List<ResponseUserDto>>(userEntities);

                
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(10))  
                    .SetAbsoluteExpiration(TimeSpan.FromHours(1));  

               
                _memoryCache.Set(cacheKey, users, cacheEntryOptions);
            }

            return users;
        }

        public User GetUserById(int id)
        {
            var user = _userRepository.GetById(id);
            return user;
        }

        public User GetUserByUsername(string username)
        {
            //var user = _userRepository.GetByUserName(username);
            //return user;
        
          

           
            if (!_memoryCache.TryGetValue($"user_{username}", out User user))
            {
                
                user = _userRepository.GetByUserName(username);

                if (user != null)
                {
                   
                    var cacheEntryOptions = new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromMinutes(10))  
                        .SetAbsoluteExpiration(TimeSpan.FromHours(1));  

                    // Store the user in the cache
                    _memoryCache.Set($"user_{username}", user, cacheEntryOptions);
                }
            }

            return user;
        }
        public string Login(UserLoginDto loginDto)
        {
            var user = _userRepository.GetByUserName(loginDto.UserName);
            if (user == null || user.Password != loginDto.Password)
            {
                throw new UnauthorizedAccessException("Access denied. Please verify your credentials.");
            }
            return GenerateJwtToken(user);

        }
        private string GenerateJwtToken(User user)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            SigningCredentials credentials = new SigningCredentials(
                securityKey, SecurityAlgorithms.HmacSha256);

            Claim[] claims = new[]
            {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Role, user.Role)
            };

            JwtSecurityToken token = new JwtSecurityToken(
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
