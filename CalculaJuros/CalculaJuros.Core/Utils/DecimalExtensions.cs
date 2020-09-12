using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CalculaJuros.Core.Utils
{
    public static class DecimalExtensions
    {

        /// <summary>
        /// Truca um Decimal para a precisão recebida.
        /// Adaptado de: https://stackoverflow.com/questions/3143657/truncate-two-decimal-places-without-rounding
        /// </summary>
        public static decimal Truncate(this decimal d, byte decimals)
        {
            decimal r = Math.Round(d, decimals);

            if(d > 0 && r > d)
            {
                return r - new decimal(1, 0, 0, false, decimals);
            }
            else if(d < 0 && r < d)
            {
                return r + new decimal(1, 0, 0, false, decimals);
            }

            return r;
        }


        ///// <summary>
        ///// Exponenciação binária da esquerda para a direita.
        //// Adaptado de: http://www.daimi.au.dk/~ivan/FastExpproject.pdf
        ///// </summary>
        //public static decimal Pow(this decimal x, uint y)
        //{
        //    decimal A = 1m;
        //    BitArray e = new BitArray(BitConverter.GetBytes(y));
        //    int t = e.Count;

        //    for(int i = t - 1; i >= 0; --i)
        //    {
        //        A *= A;
        //        if(e[i] == true)
        //        {
        //            A *= x;
        //        }
        //    }
        //    return A;
        //}
    }
}
