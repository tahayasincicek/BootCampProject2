using AutoMapper;
using Business.DTOs;
using Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class BootcampProfile : Profile
{
    public BootcampProfile()
    {
        CreateMap<Bootcamp, BootcampDTO>().ReverseMap();
    }
}
