using Microsoft.AspNetCore.Mvc;
using TicketsNetBackend.Models.Dto;

namespace TicketsNetBackend.Services
{
    public interface IEventService
    {
        Task<EventsDto> GetAllAsync();
        Task<EventDto> GetByIdAsync(int id);
    }
}
