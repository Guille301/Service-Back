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
        private readonly IEliminarAmigos _eliminarAmigos;


        public AmigoController(IAgregarAmigos agregarAmigos, IEliminarAmigos eliminarAmigos)
        {
            _agregarAmigos = agregarAmigos;
            _eliminarAmigos = eliminarAmigos;
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


        //Eliminar
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            try
            {
                _eliminarAmigos.EliminarAmigos(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = $"No se pudo eliminar al amigo. Detalle: {ex.Message}" });
            }



        }

















    }
}
