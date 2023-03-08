using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HR.Domain.Enum
{
    public enum Currency
    {
        [Display(Name = "₺")]
        TL,
         [Display(Name = "€")]
        EURO,
         [Display(Name = "$")]
        DOLAR,
         [Display(Name = "₽")]
        RUBLE,
         [Display(Name = "¥")]
        YUAN,


    }
}
