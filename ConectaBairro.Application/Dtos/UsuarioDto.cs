using System.ComponentModel.DataAnnotations;

namespace ConectaBairro.Application.Dtos
{
    public record UsuarioDto
    {
        public string Nome { get; set; } = String.Empty;
        public string Sobrenome { get; set; } = String.Empty;
        [EmailAddress]
        public string Email { get; set; } = String.Empty;
        public DateOnly DataNascimento { get; set; }
        public int TipoContaId { get; set; }
        public byte[]? Foto { get; set; } = null;
        public string Password { get; set; } = String.Empty;
    }
}
