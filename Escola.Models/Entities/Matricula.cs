using Escola.Models.Enums;

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
