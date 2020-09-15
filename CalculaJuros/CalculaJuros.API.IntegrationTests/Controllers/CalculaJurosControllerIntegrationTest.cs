using CalculaJuros.API.IntegrationTests.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace CalculaJuros.API.IntegrationTests.Controllers
{
    public class CalculaJurosControllerIntegrationTest : BaseIntegrationTest
    {
        public CalculaJurosControllerIntegrationTest(BaseTestFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task Get_IntegrationTest()
        {
            var valorInicial = 100M;
            var tempo = 5M;
            var esperado = 105.10M;

            var response = CriaRequisicao(valorInicial, tempo).Result;

            Assert.Equal(200, (int)response.StatusCode);

            var resultadoCalculo = JsonConvert.DeserializeObject<decimal>(await response.Content.ReadAsStringAsync());
            Assert.Equal(esperado, resultadoCalculo);

        }

        [Fact]
        public async Task Get_ValorNegativo_IntegrationTest()
        {
            var valorInicial = 100M;
            var tempo = -5M;
            var esperado = "Não foi possivel realizar o calculo de Juros, os valores devem ser maiores que zero.";

            var response = CriaRequisicao(valorInicial, tempo).Result;

            Assert.Equal(400, (int)response.StatusCode);

            var resultado = JsonConvert.DeserializeObject<string>(await response.Content.ReadAsStringAsync());
            Assert.NotNull(resultado);
            Assert.Equal(esperado, resultado);

        }

        private async Task<HttpResponseMessage> CriaRequisicao(decimal valorInicial, decimal tempo)
        {
            return await Server
                .CreateRequest($"api/calculaJuros?valorInicial={valorInicial}&tempo={tempo}")
                .GetAsync(); 
        }
    }
}
