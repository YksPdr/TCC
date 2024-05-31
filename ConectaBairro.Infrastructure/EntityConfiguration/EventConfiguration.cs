using ConectaBairro.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ConectaBairro.Infrastructure.EntityConfiguration
{
    public static class EventConfiguration
    {
        public static void ConfigureEvent(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Evento>(entity =>
            {
                entity.ToTable("evento");
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Id).UseIdentityColumn();
                entity.Property(u => u.Titulo)
                    .IsRequired()
                    .HasMaxLength(255);
                entity.Property(u => u.Descricao)
                    .HasColumnType("text");
                entity.Property(u => u.LimiteParticipantes)
                    .IsRequired();
                entity.Property(u => u.DataInicio)
                    .IsRequired();
                entity.Property(u => u.DataFim)
                    .IsRequired();
                entity.Property(u => u.ValorIngresso)
                    .HasPrecision(8, 2)
                    .IsRequired();
                entity.Property(u => u.HorarioInicio);
                entity.Property(u => u.HorarioFim);


                entity.HasOne(u => u.Categorias)
                      .WithMany()
                      .HasForeignKey(u => u.CategoriaId)
                      .OnDelete(DeleteBehavior.Cascade);
                
                entity.HasOne(u => u.Usuarios)
                    .WithMany()
                    .HasForeignKey(u => u.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
