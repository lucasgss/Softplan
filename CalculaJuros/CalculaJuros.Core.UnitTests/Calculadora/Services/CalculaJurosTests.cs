using CalculaJuros.Core.Calculadora.Interfaces;
using CalculaJuros.Core.Calculadora.Services;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CalculaJuros.Core.UnitTests.Calculadora.Services
{
    public class CalculaJurosTests
    {
        const decimal VALID_VALOR_INICIAL = 100;
        const decimal VALID_TAXA_JUROS = 0.01M;
        const int VALID_TEMPO = 5;
        readonly Mock<ITaxaJurosService> _taxaJurosServiceMock;
        readonly CalculaJurosService _service;
        public CalculaJurosTests()
        {
            _taxaJurosServiceMock = new Mock<ITaxaJurosService>();
            _service = new CalculaJurosService(_taxaJurosServiceMock.Object);
        }

        [Fact]
        public void Calcular_ComValoresValidos_DeveChamarTaxaJurosService_ERetornarDecimal()
        {
            _taxaJurosServiceMock.Setup(_ => _.GetTaxaJuros()).Returns(Task.FromResult(VALID_TAXA_JUROS));

            var result = _service.Calcular(VALID_VALOR_INICIAL, VALID_TEMPO).Result;

            _taxaJurosServiceMock.Verify(_ => _.GetTaxaJuros(), Times.Once);

            Assert.IsType<decimal>(result);
        }

        [Fact]
        public async Task Calcular_ComValorInicialNegativo_DeveChamarTaxaJurosService_ERetornarErro()
        {
            var esperado = "Não foi possivel realizar o calculo de Juros, os valores devem ser maiores que zero.";
            _taxaJurosServiceMock.Setup(_ => _.GetTaxaJuros()).Returns(Task.FromResult(VALID_TAXA_JUROS));

            Task testeErro() => Task.Run(() => _service.Calcular(-100, VALID_TEMPO));

            var exception = await Record.ExceptionAsync(testeErro);

            _taxaJurosServiceMock.Verify(_ => _.GetTaxaJuros(), Times.Once);

            Assert.NotNull(exception);
            Assert.IsType<ArgumentException>(exception);
            Assert.Equal(esperado, exception.Message);
        }

        [Fact]
        public async Task Calcular_ComTempoNegativo_DeveChamarTaxaJurosService_ERetornarErro()
        {
            var esperado = "Não foi possivel realizar o calculo de Juros, os valores devem ser maiores que zero.";
            _taxaJurosServiceMock.Setup(_ => _.GetTaxaJuros()).Returns(Task.FromResult(VALID_TAXA_JUROS));

            Task testeErro() => Task.Run(() => _service.Calcular(VALID_VALOR_INICIAL, -5));

            var exception = await Record.ExceptionAsync(testeErro);

            _taxaJurosServiceMock.Verify(_ => _.GetTaxaJuros(), Times.Once);

            Assert.NotNull(exception);
            Assert.IsType<ArgumentException>(exception);
            Assert.Equal(esperado, exception.Message);
        }
    }
}
