using Escola.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
