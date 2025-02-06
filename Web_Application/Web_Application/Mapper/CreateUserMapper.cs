using AutoMapper;
using Web_Application.Models;
using Web_Application.ViewModels;

namespace Web_Application.Mapper
{
    public class CreateUserMapper:Profile
    {
        public CreateUserMapper()
        {
            CreateMap<User, CreateUserDto>();
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<ResponseUserDto, CreateUserDto>().ReverseMap();
            CreateMap<User, ResponseUserDto>();
        }
    }
}
