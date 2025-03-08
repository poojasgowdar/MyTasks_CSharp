using AutoMapper;
using DTOs.DTO;
using Models.Entities;

namespace TaskController.Controllers
{
    public class MyMappingProfile:Profile
    {
        public MyMappingProfile()
        {
            CreateMap<TaskItem, TaskDto>().ReverseMap();
        }
    }
}
