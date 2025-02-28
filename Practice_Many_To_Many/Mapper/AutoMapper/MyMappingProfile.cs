using AutoMapper;
using DTOs.Dto;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper.AutoMapper
{
    public class MyMappingProfile:Profile
    {
        public MyMappingProfile()
        {
            // Mapping Product -> ProductDTO
            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.CategoryIds, opt =>
                    opt.MapFrom(src => src.ProductCategories.Select(pc => pc.CategoryId).ToList()));

            // Mapping ProductDTO -> Product
            CreateMap<ProductDTO, Product>()
                .ForMember(dest => dest.ProductCategories, opt =>
                    opt.MapFrom(src => src.CategoryIds.Select(id => new ProductCategory { CategoryId = id }).ToList()));

        }
    }
}
