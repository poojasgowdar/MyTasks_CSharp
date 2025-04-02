using AutoMapper;
using MiniOffice365Backend.DataAccess.DBModel;
using MiniOffice365Backend.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniOffice365Backend.WebApi
{
    public class MyMappingProfile:Profile
    {
        public MyMappingProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Email, EmailDTO>().ReverseMap();
            CreateMap<Event, EventDTO>().ReverseMap();
        }
    }
}
