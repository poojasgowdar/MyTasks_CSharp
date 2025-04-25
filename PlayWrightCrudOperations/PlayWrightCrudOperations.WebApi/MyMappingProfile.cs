using AutoMapper;
using PlayWrightCrudOperations.DataAccess;
using PlayWrightCrudOperations.Models.DTO;

namespace PlayWrightCrudOperations.WebApi
{
    public class MyMappingProfile : Profile
    {
        public MyMappingProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
