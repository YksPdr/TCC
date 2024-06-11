using ConectaBairro.Application.Dtos;

namespace ConectaBairro.Application.Services
{
    public interface ILoginService
    {
        public Task<object> Authenticate(LoginDto loginDto);
    }
}
