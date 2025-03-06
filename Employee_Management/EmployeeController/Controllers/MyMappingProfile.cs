using AutoMapper;
using DTOs.dto;
using Models.Entities;

namespace EmployeeController.Controllers
{
    public class MyMappingProfile : Profile
    {   
        public MyMappingProfile()
        {
            CreateMap<Employee, EmployeeDTO>().ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.Ignore()); 
        }
    }
}
