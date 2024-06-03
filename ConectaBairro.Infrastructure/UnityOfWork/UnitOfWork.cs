using ConectaBairro.Infrastructure.Data;

namespace ConectaBairro.Infrastructure.UnityOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}
