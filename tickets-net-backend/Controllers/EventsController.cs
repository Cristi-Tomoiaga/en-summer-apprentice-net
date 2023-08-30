using Microsoft.AspNetCore.Mvc;
using tickets_net_backend.Models.Dto;
using tickets_net_backend.Services;

namespace tickets_net_backend.Controllers
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
        public async Task<ActionResult<List<EventDto>>> GetAll()
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
