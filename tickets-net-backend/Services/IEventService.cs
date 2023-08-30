using Microsoft.AspNetCore.Mvc;
using tickets_net_backend.Models.Dto;

namespace tickets_net_backend.Services
{
    public interface IEventService
    {
        Task<List<EventDto>> GetAllAsync();
        Task<EventDto> GetByIdAsync(int id);
    }
}
