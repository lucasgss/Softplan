using System;
using System.Collections.Generic;
using System.Text;
using TaxaJuros.Core.Juros.Interfaces;

namespace TaxaJuros.Core.Juros.Models
{
    public class Juros : IJuros
    {
        public decimal Valor => 0.01M;
    }
}
