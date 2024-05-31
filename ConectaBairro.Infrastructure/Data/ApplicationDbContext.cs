using ConectaBairro.Domain.Models;
using ConectaBairro.Infrastructure.EntityConfiguration;
using ConectaBairro.Infrastructure.SeedConfiguration;
using Microsoft.EntityFrameworkCore;

namespace ConectaBairro.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Conta> Contas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AccountTypeConfiguration.ConfigureAccount(modelBuilder);
            SeedAccountType.CreateAccountTypeSeed(modelBuilder);
            UserConfiguration.ConfigureUser(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}
