using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CalculaJuros.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowMeTheCodeController : ControllerBase
    {
        /// <summary>
        /// Obter a url onde encontra-se o fonte no github.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get()
        {

            return Ok("https://github.com/lucasgss/Softplan");

        }
    }
}
