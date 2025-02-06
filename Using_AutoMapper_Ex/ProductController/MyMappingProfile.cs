using AutoMapper;
using dtos.dto;
using Models.Entities;

namespace ProductController
{
    public class MyMappingProfile:Profile
    {
        public MyMappingProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}


