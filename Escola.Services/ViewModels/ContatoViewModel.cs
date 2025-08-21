using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Services.ViewModels
{
    public class ContatoViewModel
    {
        public int Id { get; set; }
        public int AlunoId { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio")]
        [MaxLength(20)]
        public required string Telefone { get; set; }
        public bool Celular { get; set; }
    }

    public class ContatoCreateViewModel
    {
        public int AlunoId { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio")]
        [MaxLength(20)]
        public required string Telefone { get; set; }
        public bool Celular { get; set; }
    }
}
