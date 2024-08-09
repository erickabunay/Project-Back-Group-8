using API_ElectroUG.Models;

namespace API_ElectroUG.Repository
{
    public interface IEventRepository
    {
        Task<List<Event>> GetAllEventAsync();

        Task<Event> GetEventByIdAsync(int id);

        Task<Event> GetEventByNameAsync(string eventName);

        Task<List<Event>> GetEventByEndDateAsync(DateTime endDateEvent);

        Task<Event> CreateEventAsync(Event createEvent);

        Task<Event> UpdateEventAsync(Event updateEvent);

        Task<Event> DisabledEventByIdAsync(int eventId);
    }
}
