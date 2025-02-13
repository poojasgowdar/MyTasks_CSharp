using AutoMapper;
using Product_MVC_Project.dtos;

namespace Product_MVC_Project.Models
{
    public class MyMappingProfile : Profile
    {
        public MyMappingProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
