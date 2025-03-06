using AutoMapper;
using DTOs.DTO;
using Models.Entities;

namespace UserController.Controllers
{
    public class MyMappingProfile : Profile
    {
        public MyMappingProfile()
        {
            CreateMap<CreateUserDto, User>();
            CreateMap<User, ResponseUserDto>();
        }
    }
}
