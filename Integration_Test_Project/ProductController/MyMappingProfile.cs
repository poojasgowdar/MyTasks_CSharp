using AutoMapper;
using DAL.Data;
using DTO.DTOs;

namespace Mapper.AutoMapper
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
