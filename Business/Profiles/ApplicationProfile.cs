using AutoMapper;
using Business.DTOs;
using Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Business.Profiles
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            // Entity → DTO (Response)
            CreateMap<Application, ApplicationResponse>()
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.ApplicationState.ToString()));

            // DTO (Request) → Entity
            CreateMap<CreateApplicationRequest, Application>();
        }
    }
}
