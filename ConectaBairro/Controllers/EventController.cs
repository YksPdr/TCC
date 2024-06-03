using ConectaBairro.Application.Dtos;
using ConectaBairro.Application.Services;
using ConectaBairro.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


using Microsoft.AspNetCore.Identity;
namespace ConectaBairro.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        [Authorize(Policy = "Organizador")]
        public async Task<ActionResult<List<Evento>>> GetEventos()
        {
            var eventos = await _eventService.GetEventsAsync();
            return Ok(eventos);
        }

        [HttpPost]
        [Authorize(Policy = "Organizador")]
        public async Task<ActionResult<Evento>> CreateEventosAsync([FromBody] CreateEventDto evento)
        {
            try
            {
                string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
                var novoEvento = await _eventService.CreateEventAsync(evento, Convert.ToInt32(userId));

                return Ok(novoEvento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
