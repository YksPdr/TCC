using ConectaBairro.Domain.Models.Enums;

namespace ConectaBairro.Domain.Models
{
    public sealed class Categoria
    {
        public Categoria(int id, TipoCategoria nome, string descricao)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
        }

        public int Id { get; set; }
        public TipoCategoria Nome { get; set; }
        public string Descricao { get; set; }
    }
}
