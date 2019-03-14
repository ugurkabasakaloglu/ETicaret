using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ETicaretWebMvc.Models
{
    public enum EnumOrderState
    {
        [Display(Name ="Onay Bekleniyor")]
        Bekliyor,
        Tamamlandı
    }
}