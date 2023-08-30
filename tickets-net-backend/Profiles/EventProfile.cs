using AutoMapper;
using TicketsNetBackend.Models;
using TicketsNetBackend.Models.Dto;

namespace TicketsNetBackend.Profiles
{
    public class EventProfile : Profile
    {
        public EventProfile() 
        {
            CreateMap<Venue, VenueDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.VenueId));

            CreateMap<TicketCategory, TicketCategoryDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.TicketCategoryId));

            CreateMap<Event, EventDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.EventId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.EventName))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.EventDescription))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.EventType.EventTypeName))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.ImageUrl));
        }
    }
}
