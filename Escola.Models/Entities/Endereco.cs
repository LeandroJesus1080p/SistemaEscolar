using Escola.Models.Enums;

namespace Escola.Models.Entities
{
    public class Endereco : Table
    {
        public int AlunoId { get; set; }
        public required string Logradouro { get; set; }
        public required string Numero { get; set; }
        public string? Complemento { get; set; }
        public required string Bairro { get; set; }
        public required string Cidade { get; set; }
        public EstadoEnum Estado { get; set; }
        public string? Cep { get; set; }

        public Aluno? Aluno { get; set; }
    }
}
