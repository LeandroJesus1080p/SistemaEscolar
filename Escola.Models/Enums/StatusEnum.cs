using System.ComponentModel.DataAnnotations;

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
