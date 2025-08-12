namespace Escola.Models.Entities
{
    public class Contato : Table
    {
        public int AlunoId { get; set; }
        public required string Telefone { get; set; }
        public bool Celular { get; set; }

        public Aluno? Aluno { get; set; }
    }
}
