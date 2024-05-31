using ConectaBairro.Application.Dtos;
using ConectaBairro.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConectaBairro.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public sealed class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUserAsync(UsuarioDto user)
        {
            await _usersService.CreateUserAsync(user);
            return Created(nameof(UsersController), user.Email);
        }
    }
}
