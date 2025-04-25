using AutoMapper;
using DataAccessLayer.Entities;
using DTO;

namespace ProductController.Controllers
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
