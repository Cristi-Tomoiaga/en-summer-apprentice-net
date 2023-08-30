using AutoMapper;
using tickets_net_backend.Models;
using tickets_net_backend.Models.Dto;

namespace tickets_net_backend.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile() 
        {
            CreateMap<Order, OrderGetDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.OrderId))
                .ForMember(dest => dest.Event, opt => opt.MapFrom(src => src.TicketCategory.Event))
                .ForMember(dest => dest.Timestamp, opt => opt.MapFrom(src => src.OrderedAt));
        }
    }
}
