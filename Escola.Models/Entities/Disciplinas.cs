namespace Escola.Models.Entities
{
    public class Disciplinas : Table
    {
        public required string Nome { get; set; }
        public required int CargaHoraria { get; set; }

        public virtual ICollection<TurmaDisciplinas> TurmaDisciplinas { get; set; } = [];
    }
}
