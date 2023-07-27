using AutoMapper;
using tickets_net_backend.Models;
using tickets_net_backend.Models.Dto;

namespace tickets_net_backend.Profiles
{
    public class EventProfile : Profile
    {
        public EventProfile() 
        {
            CreateMap<Event, EventDto>()
                .ForMember(dest => dest.EventType, opt => opt.MapFrom(src => src.EventType.EventTypeName))
                .ForMember(dest => dest.Venue, opt => opt.MapFrom(src => src.Venue.Location));
        }
    }
}
