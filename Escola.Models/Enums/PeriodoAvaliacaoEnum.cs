using System.ComponentModel.DataAnnotations;

namespace Escola.Models.Enums
{
    public enum PeriodoAvaliacaoEnum : int
    {
        [Display(Name = "1ºBimestre")]
        Bimestre1 = 1,
        [Display(Name = "2ºBimestre")]
        Bimestre2 = 2,
    }
}
