namespace Escola.Models.Entities
{
    public class Frequencia : Table
    {
        public int MatriculaId { get; set; }
        public int TurmaDisciplinasId { get; set; }
        public DateTime? DataAula { get; set; }
        public bool Presente { get; set; }

        public Matricula? Matricula { get; set; }
        public TurmaDisciplinas? TurmaDisciplinas { get; set; }
    }
}
