
namespace Escola.Models.Entities
{
    public class TurmaDisciplinas : Table
    {
        public int TurmaId { get; set; }
        public int DisciplinaId { get; set; }
        public int ProfessorId { get; set; }

        public Turma? Turma { get; set; }
        public Disciplinas? Disciplina { get; set; }
        public Professor? Professor { get; set; }

        public virtual ICollection<Nota> Notas { get; set; } = [];
        public virtual ICollection<Frequencia> Frequencias { get; set; } = [];

    }
}
