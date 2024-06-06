using System.ComponentModel.DataAnnotations.Schema;

namespace ConectaBairro.Domain.Models
{
    public sealed class Evento
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CategoriaId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int LimiteParticipantes { get; set; }
        public decimal ValorIngresso { get; set; }
        public DateTime? HorarioInicio { get; set; } = null;
        public DateTime? HorarioFim { get; set; } = null;

        [NotMapped]
        public Usuario Usuarios { get; set; }
        [NotMapped]
        public Categoria Categorias { get; set; }
    }
}
