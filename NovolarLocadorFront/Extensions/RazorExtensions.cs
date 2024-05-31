using Microsoft.AspNetCore.Mvc.Razor;
using NovolarLocadorFront.Models.Enums;
using System;

namespace NovolarLocadorFront.Extensions
{
    public static class RazorExtensions
    {
        public static string FormataDocumento(this RazorPage page, EnumTipoPessoa tipoPessoa, string documento)
        {
            return tipoPessoa == EnumTipoPessoa.PF ? Convert.ToUInt64(documento).ToString(format: @"000\.000\.000-00") :
                Convert.ToUInt64(documento).ToString(format: @"00\.000\.000\/0000-00");
        }

        public static string RetornaStatusAluguel(this RazorPage page, bool status)
        {
            return status == true ? "Alugado" :
                "Desalugado";
        }


    }
}
