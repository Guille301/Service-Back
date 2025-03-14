using Compartido.DTOS.Amigos;
using Compartido.DTOS.Cliente;
using LogicaAplicacion.InterfaceCU.AmigosInterface;
using LogicaAplicacion.InterfaceCU.BuscadorInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmigoController : ControllerBase
    {


        private readonly IAgregarAmigos _agregarAmigos;

        public AmigoController(IAgregarAmigos agregarAmigos)
        {
            _agregarAmigos = agregarAmigos;
        }





        /*Alta*/
        [HttpPost]
        public IActionResult Create([FromBody] AgregarAmigosDTO amigoDto)
        {
            try
            {
                _agregarAmigos.AltaAmigos(amigoDto);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Ocurrió un error inesperado: " + ex.Message });
            }
        }





















    }
}
