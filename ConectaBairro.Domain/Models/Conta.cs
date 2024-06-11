using ConectaBairro.Domain.Models.Enums;

namespace ConectaBairro.Domain.Models
{
    public sealed class Conta
    {
        public Conta(int id, TipoConta tipo)
        {
            Id = id;
            Tipo = tipo;
        }

        public int Id { get; set; }
        public TipoConta Tipo { get; set; } = TipoConta.Organizador;
        public ICollection<Usuario> Usuarios { get; set; }
    }
}
