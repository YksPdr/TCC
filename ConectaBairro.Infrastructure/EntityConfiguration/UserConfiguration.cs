using ConectaBairro.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ConectaBairro.Infrastructure.EntityConfiguration
{
    public static class UserConfiguration
    {
        public static void ConfigureUser(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuario");
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Id).UseIdentityColumn();
                entity.Property(u => u.Nome)
                    .IsRequired()
                    .HasMaxLength(128);
                entity.Property(u => u.Sobrenome)
                    .IsRequired()
                    .HasMaxLength(128);
                entity.Property(u => u.Email)
                    .IsRequired()
                    .HasMaxLength(255).HasColumnType
                    ("varchar");
                entity.Property(u => u.DataNascimento)
                    .IsRequired()
                    .HasColumnType("date");
                entity.Property(u => u.Foto)
                    .HasMaxLength(255)
                    .HasColumnType("varchar");
                entity.Property(u => u.PasswordHash)
                    .HasMaxLength(255)
                    .HasColumnType("varchar");
                entity.Property(u => u.PasswordSalt)
                    .HasMaxLength(255)
                    .HasColumnType("varchar");
                entity.Property(u => u.TipoContaId)
                    .IsRequired();

                entity.HasOne(u => u.TipoDeConta)
                      .WithMany(t => t.Usuarios)
                      .HasForeignKey(u => u.TipoContaId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
