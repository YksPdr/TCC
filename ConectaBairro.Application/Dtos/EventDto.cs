using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConectaBairro.Application.Dtos
{
    public record EventDto(
        int Id,
        int UserId,
        int CategoriaId,
        string Titulo,
        string Descricao,
        DateTime DataInicio,
        DateTime DataFim,
        int LimiteParticipantes,
        decimal ValorIngresso,
        DateTime? HorarioInicio = null,
        DateTime? HorarioFim = null)
    { }
}