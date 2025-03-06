using AutoMapper;
using DTOs.Dto;
using Models.Entities;

namespace ProductController.Controllers
{
    public class MyMappingProfile : Profile
    {
        public MyMappingProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
