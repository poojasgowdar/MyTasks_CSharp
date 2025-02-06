using AutoMapper;
using EfClass.Models.DBModels;
using EfClass.Models.DBModels.DTOs;

namespace EfClass.BooksApi
{
    public class MyMappingProfile : Profile
    {
        public MyMappingProfile()
        {
            CreateMap<Book, BookDto>()
            .ForMember(x => x.AuthorName, x => x.MapFrom(y => y.Author.AuthorName))
           .ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();

        

        }
    }
}
