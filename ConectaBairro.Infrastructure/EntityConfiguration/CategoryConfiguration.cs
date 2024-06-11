using ConectaBairro.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ConectaBairro.Infrastructure.EntityConfiguration
{
    public static class CategoryConfiguration
    {
        public static void ConfigureCategory(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.ToTable("categoria");
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Nome)
                    .HasConversion<string>();
                entity.Property(u => u.Descricao)
                    .HasColumnType("text");
            });
        }
    }
}
