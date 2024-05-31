namespace ConectaBairro.Application.Services
{
    public interface ITokenService
    {
        string GenerateJwtToken(string email);
    }
}
