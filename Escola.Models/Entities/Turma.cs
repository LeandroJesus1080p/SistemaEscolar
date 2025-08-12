using Escola.Models.Enums;

namespace Escola.Models.Entities
{
    public class Turma : Table
    {
        public DateTime? AnoLetivo { get; set; }
        public required string? Serie { get; set; }
        public TurnoPeriodoEnum TurmaPeriodo { get; set; }

        public virtual ICollection<Matricula> Matriculas { get; set; } = [];
        public virtual ICollection<TurmaDisciplinas> TurmaDisciplinas { get; set; } = [];
    }
}
