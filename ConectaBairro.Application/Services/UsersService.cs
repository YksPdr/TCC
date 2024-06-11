using AutoMapper;
using ConectaBairro.Application.Dtos;
using ConectaBairro.Domain.Models;
using ConectaBairro.Infrastructure.Repository;

namespace ConectaBairro.Application.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUserRepository _userRepository;
        private readonly IHashService _hashService;
        private readonly IMapper _mapper;

        public UsersService(IUserRepository userRepository, IMapper mapper, IHashService hashService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _hashService = hashService;
        }

        public async Task<UsuarioDto> CreateUserAsync(UsuarioDto userDto)
        {
            var user = HandleUser(userDto);
            var createdUser = await _userRepository.CreateUserAsync(user);
            return _mapper.Map<UsuarioDto>(createdUser);
        }

        private Usuario HandleUser(UsuarioDto userDto)
        {
            var user = _mapper.Map<Usuario>(userDto);
            var salt = _hashService.CreateSalt();
            user.PasswordHash = _hashService.HashPassword(userDto.Password, salt);
            user.PasswordSalt = salt;

            return user;
        }
    }
}
