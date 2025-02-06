using AutoMapper;
using Dtos.Dto;
using Models.Entities;

namespace One_To_ManyController.Mappings
{
    public class CreateMapper:Profile
    {
        public CreateMapper()
        {
            CreateMap<Student, StudentDto>()
             .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.Courses.Select(c => c.CourseName).ToList()));
        }
    }
}
