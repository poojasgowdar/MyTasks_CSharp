using AutoMapper;
using EFCoreManyToMany.Database;
using EFCoreManyToMany.ViewModels;
namespace EFCoreManyToMany
{
    public class MyMappingProfile : Profile
    {
        public MyMappingProfile()
        {
           CreateMap<Database.Book, ViewModels.BookDto>()
            .ForMember(x=>x.AuthorName,x=>x.MapFrom(y=>y.Author.AuthorName))
           .ReverseMap();

            CreateMap<ViewModels.BookDto, Database.Book>();
            // CreateMap<ViewModels.BookDto, Database.Book>();
           CreateMap<Database.Author, ViewModels.AuthorDto>()
            .ReverseMap();
           CreateMap<Database.Category, ViewModels.CategoryDto>()
            .ReverseMap();

            CreateMap<User, UserDto>()
            .ForMember(x => x.Password, x => x.Ignore());

            CreateMap<UserDto, User>();

           

        }

    }
}
