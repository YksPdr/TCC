using System.ComponentModel.DataAnnotations.Schema;


namespace ConectaBairro.Domain.Models
{
    public class OrganizacaoEvento
    {
        public int IdOrganizador { get; set; }
        public int IdUsuario { get; set; }
        public string Profissao { get; set; } = string.Empty;
        public string Empresa { get; set; } = string.Empty;
        public string TelOrganizador { get; set; } = string.Empty;

        [NotMapped]
        public Usuario? Usuario { get; set; }
    }
}
