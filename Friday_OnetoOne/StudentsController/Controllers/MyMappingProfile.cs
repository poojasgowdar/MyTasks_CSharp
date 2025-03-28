﻿using AutoMapper;
using dtos.dto;
using Models.Entities;

namespace StudentsController.Controllers
{
    public class MyMappingProfile:Profile
    {
        public MyMappingProfile()
        {
            CreateMap<Student, StudentDTO>().ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<Course, CourseDTO>().ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
