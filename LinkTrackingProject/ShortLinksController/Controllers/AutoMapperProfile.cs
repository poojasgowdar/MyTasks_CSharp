using AutoMapper;
using DTOs.DTOs;
using Entities.Entities;

namespace ShortLinksController.Controllers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ShortLink, ShortLinkDTO>();
            CreateMap<CreateShortLinkDTO, ShortLink>();
        }
    }
}
