using Escola.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Models.Entities
{
    public class Matricula : Table
    {
        public int AlunoId { get; set; }
        public int TurmaId { get; set; }
        public DateTime? DataMatricula { get; set; }
        public StatusEnum Status { get; set; }

        public Aluno? Aluno { get; set; }
        public Turma? Turma { get; set; }

        public virtual ICollection<Nota> Notas { get; set; } = [];
        public virtual ICollection<Frequencia> Frequencias { get; set; } = [];
    }
}
