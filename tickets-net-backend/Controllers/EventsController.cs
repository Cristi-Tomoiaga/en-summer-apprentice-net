using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tickets_net_backend.Models.Dto;
using tickets_net_backend.Repositories;

namespace tickets_net_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;

        public EventsController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        [HttpGet]
        public ActionResult<List<EventDto>> GetAll()
        {
            var events = _eventRepository.GetAll();

            var eventsDto = events.Select(e => new EventDto
            {
                EventId = e.EventId,
                EventName = e.EventName ?? string.Empty,
                EventDescription = e.EventDescription ?? string.Empty,
                EventType = e.EventType?.EventTypeName ?? string.Empty,
                Venue = e.Venue?.Location ?? string.Empty
            });

            return Ok(eventsDto);
        }

        [HttpGet("{id}")]
        public ActionResult<EventDto> GetById(int id)
        {
            var foundEvent = _eventRepository.GetById(id);

            if (foundEvent == null)
            {
                return NotFound();
            }

            var eventDto = new EventDto
            {
                EventId = foundEvent.EventId,
                EventName = foundEvent.EventName ?? string.Empty,
                EventDescription = foundEvent.EventDescription ?? string.Empty,
                EventType = foundEvent.EventType?.EventTypeName ?? string.Empty,
                Venue = foundEvent.Venue?.Location ?? string.Empty
            };

            return Ok(eventDto);
        }
    }
}
