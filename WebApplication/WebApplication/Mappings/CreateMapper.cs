using AutoMapper;
using DataAccess.Models;
using Models.Dtos;

namespace WebApplication.Mappings
{
    public class CreateMapper : Profile
    {
        public CreateMapper()
        {
            // Mapping Product to ProductCreateDto and reverse
            CreateMap<Product, ProductCreateDto>().ReverseMap();

            // Mapping ResponseDto to ProductCreateDto and reverse
            CreateMap<ResponseDto, ProductCreateDto>().ReverseMap();
        }
    }
}
