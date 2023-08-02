using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClienteCRUDLogica
{
    public static class UtilLogica
    {
        public static bool IsCPF(string documento)
        {
            var primeiroDigitoDocumentoInformado = int.Parse(documento.Substring(9, 1));
            var segundoDigitoDocumentoInformado = int.Parse(documento.Substring(10, 1));

            var docTeste = documento.Substring(0, 9);
            var dv1 = RetornarDigitoVerificador(docTeste);

            docTeste += dv1;
            docTeste = documento.Substring(1, 9);

            var dv2 = RetornarDigitoVerificador(docTeste);

            return dv1 == primeiroDigitoDocumentoInformado && dv2 == segundoDigitoDocumentoInformado;
        }

        private static int RetornarDigitoVerificador(string documento)
        {
            var arrDoc = documento.Substring(0, 9).Select(x => x.ToString()).ToArray();
            var regiaoEmissoraCPF = arrDoc[8];

            /*
                1 – DF, GO, MS, MT e TO
                2 – AC, AM, AP, PA, RO e RR
                3 – CE, MA e PI
                4 – AL, PB, PE, RN
                5 – BA e SE
                6 – MG
                7 – ES e RJ
                8 – SP
                9 – PR e SC
                0 – RS
             */

            var dv = 0;

            for (int x = 10, y = 0; x >= 2; x--, y++)
            {
                var digito = int.Parse(arrDoc[y]);

                dv += digito * x;
            }

            return CalcularDigito(dv);
        }

        private static int CalcularDigito(int digito)
        {
            var restoDivisao = digito % 11;

            return (restoDivisao < 2) ? 0 : 11 - restoDivisao;
        }

        public static int GetIdade(DateTime start)
        {
            var hoje = DateTime.Now;

            return (hoje.Year - start.Year - 1) +
                (((hoje.Month > start.Month) ||
                ((hoje.Month == start.Month) && (hoje.Day >= start.Day))) ? 1 : 0);
        }
    }
}
