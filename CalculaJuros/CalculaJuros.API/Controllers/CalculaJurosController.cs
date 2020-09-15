using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CalculaJuros.Core.Calculadora.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CalculaJuros.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CalculaJurosController : ControllerBase
    {
        private readonly ICalculaJurosService _calculaJurosService;

        public CalculaJurosController(ICalculaJurosService calculaJurosService)
        {
            _calculaJurosService = calculaJurosService;
        }
        /// <summary>
        /// Obter o calculo de de juros compostos.
        /// Valor Final = Valor Inicial * (1 + juros) ^ Tempo
        /// </summary>
        /// <param name="valorInicial">Valor inicial é um decimal.</param>
        /// <param name="tempo">Tempo é um inteiro, que representa meses.</param>
        /// <returns>Valor do calculo de Juros composto</returns>
        /// <response code="200">Retorna o valor da Taxa de Juros</response>
        /// <response code="400">Se houver problemas de validação de dados.</response>   
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAsync([FromQuery][BindRequired] decimal valorInicial, [FromQuery][BindRequired] int tempo)
        {
            try
            {
                var result = await _calculaJurosService.Calcular(valorInicial, tempo);
                
                return Ok(result);
            }
            catch(Exception ex)
            {
               return BadRequest(ex.Message);
            }

        }
    }
}
