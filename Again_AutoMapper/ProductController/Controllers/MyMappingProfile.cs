using AutoMapper;
using dtos.Dto;
using Models.Entities;

namespace ProductController.Controllers
{
    public class MyMappingProfile :Profile
    {
        public MyMappingProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
