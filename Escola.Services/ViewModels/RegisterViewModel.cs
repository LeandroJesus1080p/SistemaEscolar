using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Services.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "O nome é obrigatorio")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "O E-mail e obrigatorio")]
        [EmailAddress(ErrorMessage = "O E-mail e invalido")]
        public required string Email { get; set; }
    }
}
