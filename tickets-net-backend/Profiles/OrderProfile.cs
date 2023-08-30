using AutoMapper;
using TicketsNetBackend.Models;
using TicketsNetBackend.Models.Dto;

namespace TicketsNetBackend.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile() 
        {
            CreateMap<Order, OrderGetDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.OrderId))
                .ForMember(dest => dest.Event, opt => opt.MapFrom(src => src.TicketCategory.Event))
                .ForMember(dest => dest.Timestamp, opt => opt.MapFrom(src => src.OrderedAt));

            CreateMap<List<Order>, OrdersDto>()
                .ForMember(dest => dest.Orders, opt => opt.MapFrom(src => src));
        }
    }
}
