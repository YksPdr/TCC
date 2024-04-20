using BairroConnectAPI.Data;
using BairroConnectAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BairroConnectAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly DataContext _context;

        public EventoController(DataContext context)
        {
            _context = context;
        }

        #region GET 

        [HttpGet]
        public async Task<ActionResult<List<Evento>>> GetEventos()
        {
            return await _context.TB_EVENTO.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Evento>> GetEvento(int id)
        {
            var evento = await _context.TB_EVENTO.FindAsync(id);

            if (evento == null)
            {
                return NotFound();
            }

            return evento;
        }

        #endregion

        #region POST 

        [HttpPost]
        public async Task<ActionResult<Evento>> PostEvento(Evento evento)
        {
            _context.TB_EVENTO.Add(evento);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEvento), new { id = evento.idEvento }, evento);
        }

        #endregion

        #region PUT 

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvento(int id, Evento evento)
        {
            if (id != evento.idEvento)
            {
                return BadRequest();
            }

            var existingEvento = await _context.TB_EVENTO.FindAsync(id);
            if (existingEvento == null)
            {
                return NotFound();
            }

            _context.Entry(existingEvento).CurrentValues.SetValues(evento);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return NoContent();
        }


        #endregion

        #region DELETE 

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvento(int id)
        {
            var evento = await _context.TB_EVENTO.FindAsync(id);
            if (evento == null)
            {
                return NotFound();
            }

            _context.TB_EVENTO.Remove(evento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        #endregion
    }
}
