using AutoMapper;
using Dtos.Dto;
using POne_to_One.Entities;

namespace OneToOne.Mapper
{
    public class CreateMapper:Profile
    {
        public CreateMapper()
        {
            CreateMap<Student, StudentDto>()
               // .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName))
              .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.Course.CourseName));

            //CreateMap<StudentDto, Student>()
            //   .ForMember(dest => dest.Course, opt => opt.MapFrom(src => new Course { CourseName = src.CourseName }));


        }
    }
}
