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
            catch(Exception ex)
            {
                throw new Exception("Não foi possíuvel estabelecer conexão com o serviço TaxaJuros.");
            }
            var calculadora = new CalcularJuros(valorInicial, juros, tempo);
            if(!calculadora.IsValid())
                throw new Exception("Não foi possivel calcular a taxa de Juros, os valores devem ser maiores que zero.");
            return calculadora.Calcular();
        }
    }
}
