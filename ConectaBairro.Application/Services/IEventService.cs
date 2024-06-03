using ConectaBairro.Application.Dtos;
using ConectaBairro.Domain.Models;

namespace ConectaBairro.Application.Services
{
    public interface IEventService
    {
        public Task<List<Evento>> GetEventsAsync();
        public Task<Evento> CreateEventAsync(CreateEventDto evento, int userId);
    }
}
