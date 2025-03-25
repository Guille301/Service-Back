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

        private readonly IListarAmigos _listarAmigos;
        private readonly IListarAmigosRecomendados _listarAmigosRecomendados;


        public AmigoController(IAgregarAmigos agregarAmigos, IEliminarAmigos eliminarAmigos, IListarAmigos listarAmigos,IListarAmigosRecomendados listarRecomendados)
        {
            _agregarAmigos = agregarAmigos;
            _eliminarAmigos = eliminarAmigos;
            _listarAmigos = listarAmigos;
            _listarAmigosRecomendados = listarRecomendados;
        }





        /*Agregar amigos*/
        [HttpPost]
        public IActionResult AgregarAmigos([FromBody] AgregarAmigosDTO amigoDto)
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


        //Listar amigos propios

        [HttpGet("ListarAmigosPropios{id}")]
        public IActionResult ListarAmigosPropios(int id)
        {
            try
            {
                var cliente = _listarAmigos.ListarLosAmigosPropios(id);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return NotFound(new { mensaje = ex.Message });
            }
        }



        //Listar amigos recomendados

        [HttpGet("ListarAmigosRecomendados{id}")]
        public IActionResult ListarAmigosRecomendados(int id)
        {
            try
            {
                var cliente = _listarAmigosRecomendados.ListarLosAmigosRecomendados(id);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return NotFound(new { mensaje = ex.Message });
            }
        }







    }
}
