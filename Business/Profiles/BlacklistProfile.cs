using AutoMapper;
using Business.DTOs;
using Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class BlacklistProfile : Profile
{
    public BlacklistProfile()
    {
        CreateMap<Blacklist, BlacklistDTO>().ReverseMap();
    }
}
