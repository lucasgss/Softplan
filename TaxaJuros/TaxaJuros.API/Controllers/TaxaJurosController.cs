using Microsoft.AspNetCore.Mvc;
using TaxaJuros.Core.Juros.Interfaces;

namespace TaxaJuros.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxaJurosController : ControllerBase
    {
        IJuros _juros;
        public TaxaJurosController(IJuros juros)
        {
            _juros = juros;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_juros.Valor);
            }
            catch
            {
                return BadRequest("Não foi possivel obter a Taxa de Juros");
            }

        }
    }
}
