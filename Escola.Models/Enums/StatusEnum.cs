using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Models.Enums
{
    public enum StatusEnum : int
    {
        [Display(Name = "Ativo")]
        Ativo = 1,

        [Display(Name = "Transferido")]
        Transferido = 2,

        [Display(Name = "Concluido")]
        Concluido = 3
    }
}
