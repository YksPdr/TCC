using ConectaBairro.Domain.Models;
using ConectaBairro.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ConectaBairro.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> CreateUserAsync(Usuario user)
        {
            await _context.Usuarios.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<Usuario> GetUserByEmailAsync(string email)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
