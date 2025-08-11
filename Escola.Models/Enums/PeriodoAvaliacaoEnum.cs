using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
