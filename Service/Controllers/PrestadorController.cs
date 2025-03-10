using Compartido.DTOS.Prestador;
using LogicaAplicacion.InterfaceCU.Prestador;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestadorController : ControllerBase
    {

        private readonly IAltaPrestador _altaPrestador;
        private readonly IListarPrestadorBuscador _prestadorBuscador;
        private readonly IEditarPrestador _editarPrestador;
        private readonly IEliminarPrestador _eliminarPrestador;
        private readonly IPerfilPrestador _perfilPrestador;


        public PrestadorController(IAltaPrestador AltaPrestador, IListarPrestadorBuscador prestadorBuscador, 
                                    IEditarPrestador editarPrestador, IEliminarPrestador eliminarPrestador,
                                    IPerfilPrestador perfilPrestador)
        {
            _altaPrestador = AltaPrestador;
            _prestadorBuscador = prestadorBuscador;
            _editarPrestador = editarPrestador;
            _eliminarPrestador = eliminarPrestador;
            _perfilPrestador = perfilPrestador;
        }




        /*Alta*/
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(PrestadorAltaDto obj)
        {
            try
            {
                _altaPrestador.AltaPrestador(obj);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Ocurrió un error inesperado: " + ex.Message });
            }
        }

        /*Buscador*/
        [HttpGet("PrestadorBuscador")]
        public IActionResult GetBuscador()
        {
            try
            {
                var prestadores = _prestadorBuscador.Ejecutar();
                return Ok(prestadores);
            }
            catch (Exception ex)
            {
                return NotFound(new { mensaje = ex.Message });
            }
        }


        /*Editar*/
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EditarPrestadorDto editDto)
        {
            try
            {
                _editarPrestador.EditarPrestador(editDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }


        /*Eliminar*/
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            try
            {
                _eliminarPrestador.Ejecutar(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = $"No se pudo eliminar el cliente. Detalle: {ex.Message}" });
            }



        }


        //Mostrar perfil del prestador
        [HttpGet("MostrarPerfil{id}")]
        public IActionResult MostrarPerfil(int id)
        {
            try
            {
                var prestadores = _perfilPrestador.MostarDatos(id);
                return Ok(prestadores);
            }
            catch (Exception ex)
            {
                return NotFound(new { mensaje = ex.Message });
            }
        }




      




    
    }
}
