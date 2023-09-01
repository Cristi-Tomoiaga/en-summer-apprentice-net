using Microsoft.AspNetCore.Mvc;
using TicketsNetBackend.Models.Dto;
using TicketsNetBackend.Services;

namespace TicketsNetBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<ActionResult<EventsDto>> GetAll()
        {
            var eventsDto = await _eventService.GetAllAsync();

            return Ok(eventsDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventDto>> GetById(int id)
        {
            var foundEventDto = await _eventService.GetByIdAsync(id);

            return Ok(foundEventDto);
        }
    }
}
