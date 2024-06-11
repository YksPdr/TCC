using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConectaBairro.Domain.Models
{
    public sealed class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; } = String.Empty;
        public string Sobrenome { get; set; } = String.Empty;
        [EmailAddress]
        public string Email { get; set; } = String.Empty;
        public DateOnly DataNascimento { get; set; }
        public int TipoContaId { get; set; }
        [NotMapped]
        public Conta TipoDeConta { get; set; } // Organizador ou munícipe
        public byte?[] Foto { get; set; } = null;
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
    }
}
