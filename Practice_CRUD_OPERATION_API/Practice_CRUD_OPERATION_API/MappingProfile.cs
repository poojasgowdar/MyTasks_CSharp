using AutoMapper;
using Practice_CRUD_OPERATION_API.Models;
using Practice_CRUD_OPERATION_API.ViewModels;
namespace Practice_CRUD_OPERATION_API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Models.Student, ViewModels.StudentDto>()
              .ForMember(x => x.Title, x => x.MapFrom(y => y.Course.Title)).ReverseMap();

            CreateMap<ViewModels.StudentDto, Models.Student>();

        }
    }
}
