using CalculaJuros.Core.Calculadora.Interfaces;
using CalculaJuros.Core.Utils;
using FluentValidation;
using System;
using System.Collections.Generic;
using FluentValidation.Results;
using System.Text;
using DecimalMath;

namespace CalculaJuros.Core.Calculadora.Models
{
    public class CalcularJuros : AbstractValidator<CalcularJuros>
    {
        public CalcularJuros(decimal valorInicial, decimal taxajuros, int tempo)
        {
            ValorInicial = valorInicial;
            TaxaJuros = taxajuros;
            Tempo = tempo;
            ValidationResult = new ValidationResult();
        }
        public ValidationResult ValidationResult { get; private set; }

        public readonly decimal ValorInicial; 
        public readonly decimal TaxaJuros;  
        public readonly int Tempo;  

        public decimal Calcular()
        {
            if(!IsValid())
                return 0;

            var jurosElevadoAoTempo = DecimalEx.Pow(1 + TaxaJuros, Tempo);
            return (ValorInicial * jurosElevadoAoTempo).Truncate(2);
        }
        public virtual bool IsValid()
        {
            ValidateTempo();
            ValidateValorInicial();
            ValidateTaxaJuros();

            ValidationResult = Validate(this);

            return ValidationResult.IsValid;
        }
        private void ValidateValorInicial()
        {
            RuleFor(_ => _.ValorInicial)
                .GreaterThan(0)
                .WithMessage("O valor inicial deve ser maior que zero.");
        }
        private void ValidateTaxaJuros()
        {
            RuleFor(_ => _.TaxaJuros)
                .GreaterThan(0)
                .WithMessage("O valor da taxa de juros deve ser maior que zero.");
        }
        private void ValidateTempo()
        {
            RuleFor(_ => _.Tempo)
                .GreaterThan(0)
                .WithMessage("O valor do tempo deve ser maior que zero.");
        }
    }
}
