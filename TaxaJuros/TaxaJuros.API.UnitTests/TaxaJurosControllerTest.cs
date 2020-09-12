using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TaxaJuros.API.Controllers;
using TaxaJuros.Core.Juros.Models;
using TaxaJuros.Core.Juros.Interfaces;
using Xunit;

namespace TaxaJuros.API.UnitTests
{
    public class TaxaJurosControllerTest
    {
        Mock<IJuros> _jurosMock;
        TaxaJurosController _controller;

        public TaxaJurosControllerTest()
        {
            _jurosMock = new Mock<IJuros>();
            _controller = new TaxaJurosController(_jurosMock.Object);
        }

        [Fact]
        public void Get_DeveChamarService_Retornar200_ComValor0VirgulaZeroUm()
        {
            var valorEsperado = 0.01M;
            _jurosMock.Setup(_ => _.Valor).Returns(valorEsperado);

            var resultado = _controller.Get();

            var objResultado = Assert.IsType<OkObjectResult>(resultado);
            Assert.Equal(200, objResultado.StatusCode);

            var value = Assert.IsType<Decimal>(objResultado.Value);
            Assert.Equal(valorEsperado, value);
        }
    }
}
