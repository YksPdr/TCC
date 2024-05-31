using ConectaBairro.Domain.Models.Enums;
using ConectaBairro.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ConectaBairro.Infrastructure.SeedConfiguration
{
    public static class CategorySeed
    {
        public static void CreateCategorySeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>()
                .HasData(
                    new Categoria(1, TipoCategoria.Esportivo, "Atividades físicas e competições recreativas."),
                    new Categoria(2, TipoCategoria.Entreterimento, "Diversão e lazer para todos os gostos."),
                    new Categoria(3, TipoCategoria.Cultaral, "Exploração da arte, história e tradições."),
                    new Categoria(4, TipoCategoria.Corporativo, "Eventos voltados para negócios."),
                    new Categoria(5, TipoCategoria.Religioso, "Práticas e celebrações voltadas para a religião."),
                    new Categoria(7, TipoCategoria.Educacional, "Eventos voltados para educação"),
                    new Categoria(8, TipoCategoria.Institucional, "Eventos relacionados a organizações e instituições.")
                );
        }
    }
}
