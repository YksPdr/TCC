using ConectaBairro.Application.Dtos;
using ConectaBairro.Domain.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ConectaBairro.Application.Services
{
    public interface ILoginService
    {
        public Task<object> Authenticate(LoginDto loginDto);
    }
}
