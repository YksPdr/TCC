namespace ConectaBairro.Domain.Models
{
    public class EventoEndereco
    {
        public int IdEvento { get; set; } // chave estrangeira
        public string Endereco { get; set; } = string.Empty;
        public string NroEndereco { get; set; } = string.Empty;
        public string? Complemento { get; set; } = string.Empty;
        public string BairroEndereco { get; set; } = string.Empty;
        public string CidadeEndereco { get; set; } = string.Empty;
        public string UFEndereco { get; set; } = string.Empty;
        public string CEPEndereco { get; set; } = string.Empty;
    }
}
