using ConectaBairro.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConectaBairro.Infrastructure.Repository
{
    public interface IUserRepository
    {
        public Task<Usuario> CreateUserAsync(Usuario user);
    }
}
