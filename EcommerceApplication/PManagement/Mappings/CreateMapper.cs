using AutoMapper;
using DataAccessLayer.Models;
using Models.DTO_s;

namespace PManagement.Mappings
{
    public class CreateMapper:Profile
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
