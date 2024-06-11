using System.ComponentModel.DataAnnotations;


namespace ConectaBairro.Application.Dtos
{
    public record LoginDto
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
