using AutoMapper;
using E_Commerce_Application.DataAccessLayer;
using E_Commerce_Application.Models;
using E_Commerce_Application.ViewModels;

namespace E_Commerce_Application.MappingProfile
{
    public class CreateMapper: Profile
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
