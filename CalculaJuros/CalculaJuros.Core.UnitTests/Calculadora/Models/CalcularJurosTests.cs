using Xunit;
using CalculaJuros.Core.Calculadora.Models;
using System.Linq;
using System.Collections.Generic;

namespace CalculaJuros.Core.UnitTests.Calculadora.Models
{
    public class CalcularJurosTests
    {
        const decimal VALID_VALOR_INICIAL = 100;
        const decimal VALID_TAXA_JUROS = 0.01M;
        const int VALID_TEMPO = 5;

        #region "VALOR INICIAL"
        [Fact]
        public void ValorInicial_DeveSerMaiorQueZero()
        {
            var calculaJuros = new CalcularJuros(0.001M, VALID_TAXA_JUROS, VALID_TEMPO);

            var resultado = calculaJuros.IsValid();

            Assert.True(resultado);
            Assert.Empty(calculaJuros.ValidationResult.Errors);
        }
        [Fact]
        public void ValorInicial_NaoDeveSerMenorOuIgualZero()
        {
            var calculaJuros = new CalcularJuros(0, VALID_TAXA_JUROS, VALID_TEMPO);

            var resultado = calculaJuros.IsValid();

            Assert.False(resultado);
            Assert.NotNull(calculaJuros.ValidationResult.Errors);
            Assert.NotEmpty(calculaJuros.ValidationResult.Errors);
            Assert.NotNull(calculaJuros.ValidationResult.Errors.FirstOrDefault(_ => _.ErrorMessage == "O valor inicial deve ser maior que zero."));
        }
        #endregion
        #region "TAXA DE JUROS"
        [Fact]
        public void TaxaJuros_DeveSerMaiorQueZero()
        {
            var calculaJuros = new CalcularJuros(VALID_VALOR_INICIAL, 0.001M, VALID_TEMPO);

            var resultado = calculaJuros.IsValid();

            Assert.True(resultado);
            Assert.Empty(calculaJuros.ValidationResult.Errors);
        }
        [Fact]
        public void TaxaJuros_NaoDeveSerMenorOuIgualZero()
        {
            var calculaJuros = new CalcularJuros(VALID_VALOR_INICIAL, 0, VALID_TEMPO);

            var resultado = calculaJuros.IsValid();

            Assert.False(resultado);
            Assert.NotNull(calculaJuros.ValidationResult.Errors);
            Assert.NotEmpty(calculaJuros.ValidationResult.Errors);
            Assert.NotNull(calculaJuros.ValidationResult.Errors.FirstOrDefault(_ => _.ErrorMessage == "O valor da taxa de juros deve ser maior que zero."));
        }
        #endregion
        #region "TEMPO"
        [Fact]
        public void Tempo_DeveSerMaiorQueZero()
        {
            var calculaJuros = new CalcularJuros(VALID_VALOR_INICIAL, VALID_TAXA_JUROS, 1);

            var resultado = calculaJuros.IsValid();

            Assert.True(resultado);
            Assert.Empty(calculaJuros.ValidationResult.Errors);
        }
        [Fact]
        public void Tempo_NaoDeveSerMenorOuIgualZero()
        {
            var calculaJuros = new CalcularJuros(VALID_VALOR_INICIAL, VALID_TAXA_JUROS, 0);

            var resultado = calculaJuros.IsValid();

            Assert.False(resultado);
            Assert.NotNull(calculaJuros.ValidationResult.Errors);
            Assert.NotEmpty(calculaJuros.ValidationResult.Errors);
            Assert.NotNull(calculaJuros.ValidationResult.Errors.FirstOrDefault(_ => _.ErrorMessage == "O valor do tempo deve ser maior que zero."));
        }
        #endregion
        #region "CALCULO"
        [Fact]
        public void Calcular_ComValorInicial100TaxaDeJuros0Virgula01Tempo5_DeveRetornar105Virgula10()
        {
            var taxaDeJuros = 0.01M;
            var valorInicial = 100M;
            var tempo = 5;
            var esperado = 105.10M;
            var calculaJuros = new CalcularJuros(valorInicial, taxaDeJuros, tempo);

            var resultado = calculaJuros.Calcular();

            Assert.Equal(esperado, resultado);
        }
        [Theory]
        [MemberData(nameof(DecimaisInvalidos))]
        public void Calculo_ComValorMenorOuIgualZero_DeveRetornarZero(decimal valorInicial)
        {
            var calculaJuros = new CalcularJuros(valorInicial, VALID_TAXA_JUROS, VALID_TEMPO);

            var resultado = calculaJuros.Calcular();

            Assert.Equal(0, resultado);
        }
        [Theory]
        [MemberData(nameof(DecimaisInvalidos))]
        public void Calculo_ComTaxaJurosMenorOuIgualZero_DeveRetornarZero(decimal taxaJuros)
        {
            var calculaJuros = new CalcularJuros(VALID_VALOR_INICIAL, taxaJuros, VALID_TEMPO);

            var resultado = calculaJuros.Calcular();

            Assert.Equal(0, resultado);
        }
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Calculo_ComTempoMenorOuIgualZero_DeveRetornarZero(int tempo)
        {
            var calculaJuros = new CalcularJuros(VALID_VALOR_INICIAL, VALID_TAXA_JUROS, tempo);

            var resultado = calculaJuros.Calcular();

            Assert.Equal(0, resultado);
        }
        #endregion

        public static IEnumerable<object[]> DecimaisInvalidos =>
        new List<object[]>
        {
            new object[] { 0M },
            new object[] { -4.000M},
            new object[] { -0.000001M}
        };

    }
}
