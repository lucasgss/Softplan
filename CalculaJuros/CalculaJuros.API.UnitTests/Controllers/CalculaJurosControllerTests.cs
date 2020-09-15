using CalculaJuros.API.Controllers;
using CalculaJuros.Core.Calculadora.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CalculaJuros.API.UnitTests.Controllers
{
    public class CalculaJurosControllerTests
    {
        readonly Mock<ICalculaJurosService> _serviceMock;
        readonly CalculaJurosController _controller;
        public CalculaJurosControllerTests()
        {
            _serviceMock = new Mock<ICalculaJurosService>();
            _controller = new CalculaJurosController(_serviceMock.Object);
        }

        [Fact]
        public void Get_DeveChamarServico_Retorna200ComDecimal()
        {
            var RetornoEsperadoDoServico = 105.10M;
            decimal valorIncial = 100;
            int tempo = 5;

            _serviceMock.Setup(_ => _.Calcular(It.IsAny<decimal>(), It.IsAny<int>())).Returns(Task.FromResult(RetornoEsperadoDoServico));

            var resultado = _controller.GetAsync(valorIncial, tempo).Result;

            _serviceMock.Verify(_ => _.Calcular(It.IsAny<decimal>(), It.IsAny<int>()), Times.Once);

            var objResult = Assert.IsType<OkObjectResult>(resultado);
            Assert.Equal(200, objResult.StatusCode);

            var resultadoCalculo = Assert.IsType<decimal>(objResult.Value);
            Assert.Equal(RetornoEsperadoDoServico, resultadoCalculo);
        }

    }
}
