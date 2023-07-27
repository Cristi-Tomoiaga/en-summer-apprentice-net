using AutoMapper;
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
        private readonly IMapper _mapper;

        public EventsController(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<EventDto>>> GetAll()
        {
            var events = await _eventRepository.GetAllAsync();

            var eventsDto = _mapper.Map<List<EventDto>>(events);

            return Ok(eventsDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventDto>> GetById(int id)
        {
            var foundEvent = await _eventRepository.GetByIdAsync(id);

            if (foundEvent == null)
            {
                return NotFound();
            }

            var eventDto = _mapper.Map<EventDto>(foundEvent);

            return Ok(eventDto);
        }
    }
}
