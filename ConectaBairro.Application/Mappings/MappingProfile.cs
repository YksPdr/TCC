using AutoMapper;
using ConectaBairro.Application.Dtos;
using ConectaBairro.Domain.Models;

namespace ConectaBairro.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Usuario, UsuarioDto>();
            CreateMap<UsuarioDto, Usuario>();
            CreateMap<EventDto, Evento>();
            CreateMap<Evento, EventDto>();
            CreateMap<Evento, CreateEventDto>();
            CreateMap<CreateEventDto, Evento>();
        }
    }
}
