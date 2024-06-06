using ConectaBairro.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ConectaBairro.Infrastructure.EntityConfiguration
{
    public static class AccountTypeConfiguration
    {
        public static void ConfigureAccount(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conta>(entity =>
            {
                entity.ToTable("tipo_conta");
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Id)
                    .HasColumnType("tinyint");
                entity.Property(c => c.Tipo)
                    .HasConversion<string>()
                    .HasComment("Tipo de conta baseado no ENUM da aplicação: 0 para organizador, 1 para Munícipe");
            });
        }
    }
}
