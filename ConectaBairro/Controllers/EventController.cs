using ConectaBairro.Application.Dtos;
using ConectaBairro.Application.Services;
using ConectaBairro.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
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
        [AllowAnonymous]
        public async Task<ActionResult<List<Evento>>> GetEventos()
        {
            var eventos = await _eventService.GetEventsAsync();
            return Ok(eventos);
        }

        [HttpPost]
        [Authorize(Policy = "Organizador")]
        public async Task<ActionResult<Evento>> CreateEventosAsync(CreateEventDto evento)
        {
            try
            {
                Debug.WriteLine(evento);
                string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
                int userIdFromCast = Convert.ToInt32(userId);
                var novoEvento = await _eventService.CreateEventAsync(evento, userIdFromCast);

                return Ok(novoEvento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
