using AutoMapper;
using SportsManagementApp.Entities;

public class EventRequestMapping : Profile
{
    public EventRequestMapping()
    {
        CreateMap<EventRequest, EventRequestResponseDto>()
            .ForMember(dest => dest.SportsName, opt => opt.MapFrom(src => src.Sport.Name));
    }
}