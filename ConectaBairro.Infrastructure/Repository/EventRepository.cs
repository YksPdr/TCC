
using ConectaBairro.Domain.Models;
using ConectaBairro.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ConectaBairro.Infrastructure.Repository
{
    public sealed class EventRepository : IEventRepository
    {
        private readonly ApplicationDbContext _context;
        public EventRepository(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public async Task<List<Evento>> GetEventsAsync()
        {
            return await _context.Eventos.ToListAsync();
        }

        public async Task<bool> FindEventOnDate(Evento evento)
        {
            return await _context.Eventos
                .AnyAsync(ev => ev.Titulo == evento.Titulo && ev.DataInicio.Date == evento.DataInicio.Date);
        }

        public async Task<Evento> CreateEventAsync(Evento evento)
        {
            var a = await _context.Eventos.AddAsync(evento);
            await _context.SaveChangesAsync();
            return a.Entity;
        }
    }
}
