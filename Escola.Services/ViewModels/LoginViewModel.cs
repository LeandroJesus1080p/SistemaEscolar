using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Services.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O e-mail e obrigatorio")]
        [EmailAddress(ErrorMessage = "O e-mail é invalido")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        public required string Password { get; set; }
    }
}
