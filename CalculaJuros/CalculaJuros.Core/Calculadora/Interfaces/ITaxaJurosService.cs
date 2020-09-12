using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Refit;

namespace CalculaJuros.Core.Calculadora.Interfaces
{
    public interface ITaxaJurosService
    {
        [Get("/api/TaxaJuros")]
        Task<decimal> GetTaxaJuros();
    }
}
