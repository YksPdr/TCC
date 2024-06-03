using ConectaBairro.Domain.Models;

namespace ConectaBairro.Infrastructure.Repository
{
    public interface IEventRepository
    {
        public Task<List<Evento>> GetEventsAsync();
        public Task<bool> FindEventOnDate(Evento evento);
        public Task<Evento> CreateEventAsync(Evento evento);
    }
}
