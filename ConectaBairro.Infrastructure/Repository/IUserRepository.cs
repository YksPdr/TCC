using ConectaBairro.Domain.Models;

namespace ConectaBairro.Infrastructure.Repository
{
    public interface IUserRepository
    {
        public Task<Usuario> CreateUserAsync(Usuario user);
        public Task<Usuario> GetUserByEmailAsync(string email);
    }
}
