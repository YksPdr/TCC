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
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AccountTypeConfiguration.ConfigureAccount(modelBuilder);
            SeedAccountType.CreateAccountTypeSeed(modelBuilder);
            UserConfiguration.ConfigureUser(modelBuilder);
            CategoryConfiguration.ConfigureCategory(modelBuilder);
            CategorySeed.CreateCategorySeed(modelBuilder);
            EventConfiguration.ConfigureEvent(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}
