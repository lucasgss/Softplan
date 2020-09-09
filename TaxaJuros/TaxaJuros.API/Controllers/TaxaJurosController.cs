using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TaxaJuros.Core.Juros.Interfaces;

namespace TaxaJuros.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TaxaJurosController : ControllerBase
    {
        IJuros _juros;
        public TaxaJurosController(IJuros juros)
        {
            _juros = juros;
        }
        /// <summary>
        /// Obter a taxa de Juros
        /// </summary>
        /// <returns>Valor da Taxa de Juros</returns>
        /// <response code="200">Retorna o valor da Taxa de Juros</response>
        /// <response code="500">Se der algum problema na requisição.</response>   
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get()
        {
            try
            {
                return Ok(_juros.Valor);
            }
            catch(Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }

        }
    }
}
