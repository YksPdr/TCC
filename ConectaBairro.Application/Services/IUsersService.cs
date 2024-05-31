using ConectaBairro.Application.Dtos;

namespace ConectaBairro.Application.Services
{
    public interface IUsersService
    {
        public Task<UsuarioDto> CreateUserAsync(UsuarioDto user);
    }
}
