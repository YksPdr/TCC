using ConectaBairro.Application.Dtos;
using ConectaBairro.Infrastructure.Repository;

namespace ConectaBairro.Application.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepository;
        private readonly IHashService _hashService;
        private readonly ITokenService _tokenService;
        public LoginService(IUserRepository userRepository, IHashService hashService, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _hashService = hashService;
            _tokenService = tokenService;
        }
        public async Task<object> Authenticate(LoginDto loginDto)
        {
            var user = await _userRepository.GetUserByEmailAsync(loginDto.Email);
            if(user == null || !_hashService.VerifyPassword(loginDto.Password, user.PasswordHash, user.PasswordSalt))
            {
                throw new Exception("... nhehehe sai daqui seu sapequinha");
            }

            var token = _tokenService.GenerateJwtToken(loginDto.Email);
            var sessionCode = Guid.NewGuid().ToString();

            return new { Token = token, SessionCode = sessionCode };
        }

    }
}
