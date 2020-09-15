using CalculaJuros.Core.Calculadora.Interfaces;
using CalculaJuros.Core.Calculadora.Models;
using System;
using System.Threading.Tasks;

namespace CalculaJuros.Core.Calculadora.Services
{
    public class CalculaJurosService : ICalculaJurosService
    {
        private readonly ITaxaJurosService _taxaJurosService;

        public CalculaJurosService(ITaxaJurosService taxaJurosService)
        {
            _taxaJurosService = taxaJurosService;
        }

        public async Task<decimal> Calcular(decimal valorInicial, int tempo)
        {
            decimal juros;
            try
            {
                juros = await _taxaJurosService.GetTaxaJuros();
            }
            catch
            {
                throw new Exception("Não foi possível estabelecer conexão com o serviço TaxaJuros.");
            }
            var calculadora = new CalcularJuros(valorInicial, juros, tempo);
            if(!calculadora.IsValid())
                throw new ArgumentException("Não foi possivel realizar o calculo de Juros, os valores devem ser maiores que zero.");
            return calculadora.Calcular();
        }
    }
}
