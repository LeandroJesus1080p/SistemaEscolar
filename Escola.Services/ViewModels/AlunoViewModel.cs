using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Services.ViewModels
{
    public class AlunoViewModel
    {
        [Required(ErrorMessage = "Campo obrigatorio")]
        [MaxLength(255)]
        public required string Nome { get; set; }

        public DateTime? DataNascimento { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio")]
        public required string Rg { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio")]
        public required string Cpf { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio")]
        public required string NomeResponsavel { get; set; }
    }

    public class AlunoUpdateViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio")]
        [MaxLength(255)]
        public required string Nome { get; set; }

        public DateTime? DataNascimento { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio")]
        public required string Rg { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio")]
        public required string Cpf { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio")]
        public required string NomeResponsavel { get; set; }
    }
}
