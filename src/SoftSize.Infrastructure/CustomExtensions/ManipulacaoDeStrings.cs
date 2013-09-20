using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftSize.Infrastructure.CustomExtensions
{
    public static class ManipulacaoDeStrings
    {
        public static string RemoverAcentuacao(this string textoComAcentuacao)
        {
            string comAcentos = "ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç";
            string semAcentos = "AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCc";
            for (int i = 0; i < comAcentos.Length; i++)
            {
                textoComAcentuacao = textoComAcentuacao.Replace(comAcentos[i].ToString(), semAcentos[i].ToString());
            }
            return textoComAcentuacao;
        }
    }
}
