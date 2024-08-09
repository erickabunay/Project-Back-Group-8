using API_ElectroUG.Models;
using API_ElectroUG.Repository;
using Microsoft.AspNetCore.Mvc;

namespace API_ElectroUG.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : Controller, IEventRepository
    {
        private readonly IEventRepository _eventRepository;

        public EventController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        [HttpPost("CreateEvent")]
        public async Task<Event> CreateEventAsync([FromBody] Event createEvent)
        {
            return await _eventRepository.CreateEventAsync(createEvent);
        }

        [HttpDelete("DisabledEventById/{eventId}")]
        public async Task<Event> DisabledEventByIdAsync(int eventId)
        {
            return await _eventRepository.DisabledEventByIdAsync(eventId);
        }

        [HttpGet("GetAllEvent")]

        public async Task<List<Event>> GetAllEventAsync()
        {
            return await _eventRepository.GetAllEventAsync();
        }

        [HttpGet("GetEventByDate/{endDateEvent}")]
        public async Task<List<Event>> GetEventByEndDateAsync(DateTime endDateEvent)
        {
            return await _eventRepository.GetEventByEndDateAsync(endDateEvent);
        }

        [HttpGet("GetEventById/{id}")]
        public async Task<Event> GetEventByIdAsync(int id)
        {
            return await _eventRepository.GetEventByIdAsync(id);
        }

        [HttpGet("GetEventByName/{eventName}")]
        public async Task<Event> GetEventByNameAsync(string eventName)
        {
            return await _eventRepository.GetEventByNameAsync(eventName);
        }

        [HttpPut("UpdateEvent")]
        public async Task<Event> UpdateEventAsync([FromBody] Event updateEvent)
        {
            return await _eventRepository.UpdateEventAsync(updateEvent);
        }
    }
}
