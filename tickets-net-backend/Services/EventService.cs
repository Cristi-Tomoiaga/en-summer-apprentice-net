﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TicketsNetBackend.Exceptions;
using TicketsNetBackend.Models;
using TicketsNetBackend.Models.Dto;
using TicketsNetBackend.Repositories;

namespace TicketsNetBackend.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public EventService(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<List<EventDto>> GetAllAsync()
        {
            var events = await _eventRepository.GetAllAsync();

            var eventsDto = _mapper.Map<List<EventDto>>(events);
            return eventsDto;
        }

        public async Task<EventDto> GetByIdAsync(int id)
        {
            var foundEvent = await _eventRepository.GetByIdAsync(id);
            if (foundEvent == null)
            {
                throw new EntityNotFoundException(id, nameof(Event));
            }

            var eventDto = _mapper.Map<EventDto>(foundEvent);
            return eventDto;
        }
    }
}
