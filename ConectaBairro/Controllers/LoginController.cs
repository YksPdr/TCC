using ConectaBairro.Application.Dtos;
using ConectaBairro.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConectaBairro.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public sealed class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto login)
        {
            var authenticatedUser = await _loginService.Authenticate(login);
            return Ok(authenticatedUser);
        }
    }
}
