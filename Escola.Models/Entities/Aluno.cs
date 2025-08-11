
namespace Escola.Models.Entities
{
    public class Aluno : Table
    {
        public required string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public required string Rg { get; set; }
        public required string Cpf { get; set; }
        public required string NomeResponsavel { get; set; }

        public virtual ICollection<Endereco> Enderecos { get; set; } = [];
        public virtual ICollection<Contato> Contatos { get; set; } = [];
        public virtual ICollection<Matricula> Matriculas { get; set; } = [];
    }
}
