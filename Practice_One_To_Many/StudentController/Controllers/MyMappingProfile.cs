using AutoMapper;
using Dto.dtos;
using Models.Entities;

namespace StudentController.Controllers
{
    public class MyMappingProfile:Profile
    {
        public MyMappingProfile()
        {
            CreateMap<Student, StudentDTO>().ReverseMap()
            .ForMember(dest=>dest.Id, opt=>opt.Ignore());
            CreateMap<Course, CourseDTO>().ReverseMap()
            .ForMember(dest => dest.CourseId, opt => opt.Ignore());

        }
    }
}
