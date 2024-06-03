using ConectaBairro.Domain.Models;

namespace ConectaBairro.Application.Services
{
    public interface ITokenService
    {
        string GenerateJwtToken(Usuario usuario);
    }
}
