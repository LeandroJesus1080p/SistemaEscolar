using Escola.Models.Enums;

namespace Escola.Models.Entities
{
    public class Nota : Table
    {
        public int MatriculaId { get; set; }
        public int TurmaDisciplinasId { get; set; }
        public int NotaAluno { get; set; }
        public PeriodoAvaliacaoEnum PeriodoAvaliacao { get; set; }
        public DateTime? DataAvaliacao { get; set; }

        public Matricula? Matricula { get; set; }
        public TurmaDisciplinas? TurmaDisciplinas { get; set; }
    }
}
