using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CalculaJuros.Core.Calculadora.Interfaces
{
    public interface ICalculaJurosService 
    {
        Task<decimal> Calcular(decimal valorInicial, int tempo);
    }
}
