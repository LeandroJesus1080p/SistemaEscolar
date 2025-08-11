using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Models.Entities
{
    public class Professor : Table
    {
        public required string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public required string Rg { get; set; }
        public required string Cpf { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public string? Formacao { get; set; }

        public virtual ICollection<TurmaDisciplinas> TurmaDisciplinas { get; set; } = [];
    }
}
