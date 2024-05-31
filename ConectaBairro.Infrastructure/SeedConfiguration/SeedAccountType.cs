using ConectaBairro.Domain.Models;
using ConectaBairro.Domain.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace ConectaBairro.Infrastructure.SeedConfiguration
{
    public static class SeedAccountType
    {
        public static void CreateAccountTypeSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conta>()
                .HasData(
                    new Conta(1, TipoConta.Organizador),
                    new Conta (2, TipoConta.Municipe)
                );
        }
    }
}
