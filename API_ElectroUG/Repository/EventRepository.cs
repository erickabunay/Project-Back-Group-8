using API_ElectroUG.Context;
using API_ElectroUG.Exceptions;
using API_ElectroUG.Migrations;
using API_ElectroUG.Models;
using Microsoft.EntityFrameworkCore;

namespace API_ElectroUG.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly AppDbContext _context;

        public EventRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Models.Event> CreateEventAsync(Models.Event createEvent)
        {
            _context.Eventos.Add(createEvent);
            await _context.SaveChangesAsync();
            return createEvent;
        }

        public async Task<Models.Event> DisabledEventByIdAsync(int eventId)
        {
            var existsEvent = await _context.Eventos.FindAsync(eventId);
            if (existsEvent != null)
            {
                _context.Entry(existsEvent)
                        .CurrentValues.SetValues(existsEvent.IsDisabled = true);
                await _context.SaveChangesAsync();
                return existsEvent;
            }
            else
            {
                throw new ApiException($"Operación no permitida.", 400, $"No se encontró un evento con el id: {eventId}.");
            }
        }

        public async Task<List<Models.Event>> GetAllEventAsync()
        {
            List<Models.Event> events = await _context.Eventos
                                                   .Where(p => p.IsDisabled != true)
                                                   .ToListAsync();
            return events;
        }

        public async Task<List<Models.Event>> GetEventByEndDateAsync(DateTime endDateEvent)
        {
            List<Models.Event> events = await _context.Eventos
                                                    .Where(p => p.IsDisabled != true && p.EndDate.Date <= endDateEvent)
                                                    .ToListAsync();
            return events;
        }

        public async Task<Models.Event> GetEventByIdAsync(int id)
        {
            var events = await _context.Eventos.Where(p => p.IsDisabled != true && p.EventId == id)
                                                        .FirstOrDefaultAsync();

            return events;
        }

        public async Task<Models.Event> GetEventByNameAsync(string eventName)
        {
            var events = await _context.Eventos.Where(p => p.IsDisabled != true
                                                      && p.EventName == eventName)
                                                     .FirstOrDefaultAsync();

            return events;
        }

        public async Task<Models.Event> UpdateEventAsync(Models.Event updateEvent)
        {
            var events = await _context.Eventos.Where(s => s.EventId == updateEvent.EventId
                                                        && s.IsDisabled != true).FirstOrDefaultAsync();
            if (events == null)
            {
                throw new KeyNotFoundException("Evento no encontrado.");
            }

            // Actualizar las propiedades del evento
            events.EventName = updateEvent.EventName;
            events.Description = updateEvent.Description;
            events.StartDate = updateEvent.StartDate;
            events.EndDate = updateEvent.EndDate;
            events.Localization = updateEvent.Localization;
            events.IsDisabled = updateEvent.IsDisabled;

            // Guarda los cambios en la base de datos
            _context.Eventos.Update(events);
            await _context.SaveChangesAsync();

            return events; 
        }
    }
}
