namespace ConectaBairro.Domain.Models
{
    public record JwtSettings(string Key, string Issuer, string Audience, int ExpireMinutes) { }
}
