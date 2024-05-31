using ConectaBairro.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConectaBairro.Domain.Models
{
    public sealed class Conta
    {
        public Conta(int id, TipoConta tipo)
        {
            Id = id;
            Tipo = tipo;
        }

        public int Id { get; set; }
        public TipoConta Tipo { get; set; } = TipoConta.Organizador;
        public ICollection<Usuario> Usuarios { get; set; }
    }
}
