using Escola.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Models.Entities
{
    public class Turma : Table
    {
        public DateTime? AnoLetivo { get; set; }
        public string? Serie { get; set; }
        public TurnoPeriodoEnum TurmaPeriodo { get; set; }

        public virtual ICollection<Matricula> Matriculas { get; set; } = [];
        public virtual ICollection<TurmaDisciplinas> TurmaDisciplinas { get; set; } = [];
    }
}
