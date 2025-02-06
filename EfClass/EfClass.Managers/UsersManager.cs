using AutoMapper;
using EfClass.DataAccess.Repositories;
using EfClass.Models.DBModels;
using EfClass.Models.DBModels.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfClass.Managers
{
    public  class UsersManager: IUsersManager
    {
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public UsersManager(IRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public UserDto GetUser(int id)
        {
            var user = _userRepository.GetSingleOrDefault(x => x.Id == id);
            if (user != null)
            {
                return _mapper.Map<UserDto>(user);
            }
            return null;
        }

        public UserDto GetUserByEmail(string email)
        {
            var user = _userRepository.GetSingleOrDefault(x => x.Email == email);
            if (user != null)
            {
                return _mapper.Map<UserDto>(user) as UserDto;
            }
            return null;
        }

        public List<UserDto> GetUsers()
        {
            var users = _userRepository.All();
            return _mapper.Map < List < UserDto >> (users);
        }

        public bool SaveNewUser(UserDto user)
        {
            var dbUser = _mapper.Map<User>(user);
             _userRepository.Add(dbUser);
            return true;
        }
    }
}
