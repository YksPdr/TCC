
using ConectaBairro.Domain.Models;
using ConectaBairro.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

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

        public async Task CreateEventAsync(Evento evento)
        {
            Debug.WriteLine(evento);
            await _context.Eventos.AddAsync(evento);
        }
    }
}
