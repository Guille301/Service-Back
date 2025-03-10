using Compartido.DTOS.Comentarios.ComentariosPrestador;
using Compartido.DTOS.Comentarios.ComentariosServicios;
using Microsoft.AspNetCore.Mvc;
using LogicaAplicacion.InterfaceCU.Comentarios.ComentariosPrestador;
using LogicaAplicacion.InterfaceCU.Comentarios.ComentariosServicios;

namespace Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentariosController : ControllerBase
    {
        private readonly IAltaComentarioPrestador _altaComentarioPrestador;
        private readonly IEliminarComentarioPrestador _eliminarComentarioPrestador;
        private readonly IEditarComentariosPrestador _editarComentariosPrestador;

        private readonly IAltaComentarioServicios _altaComentarioServicio;
        private readonly IEliminarComentarioServicio _eliminarComentarioServicio;
        private readonly IEditarComentariosServicio _editarComentariosServicio;

        public ComentariosController(
            IAltaComentarioPrestador altaComentarioPrestador,
            IEliminarComentarioPrestador eliminarComentarioPrestador,
            IEditarComentariosPrestador editarComentarioPrestador,
            IAltaComentarioServicios altaComentarioServicio,
            IEliminarComentarioServicio eliminarComentarioServicio,
            IEditarComentariosServicio editarComentarioServicio)
        {
            _altaComentarioPrestador = altaComentarioPrestador;
            _eliminarComentarioPrestador = eliminarComentarioPrestador;
            _editarComentariosPrestador = editarComentarioPrestador;

            _altaComentarioServicio = altaComentarioServicio;
            _eliminarComentarioServicio = eliminarComentarioServicio;
            _editarComentariosServicio = editarComentarioServicio;
        }

        /********************************************** COMENTARIOS PRESTADOR ******************************************/


        //Alta
        [HttpPost("alta-comentario-prestador")]
        public ActionResult CreateComentarioPrestador(AltaComentarioPrestadorDTO obj)
        {
            try
            {
                _altaComentarioPrestador.AltaComentarioPrestador(obj);
                return Ok(new { mensaje = "Comentario de prestador agregado correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Ocurrió un error inesperado: " + ex.Message });
            }
        }

        //Eliminar
        [HttpDelete("eliminar-comentario-prestador/{id}")]
        public IActionResult DeleteComentarioPrestador(int id)
        {
            try
            {
                _eliminarComentarioPrestador.Eliminar(id);
                return Ok(new { mensaje = "Comentario de prestador eliminado correctamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = $"No se pudo eliminar el comentario. Detalle: {ex.Message}" });
            }
        }


        //Editar
        [HttpPut("editar-comentario-prestador/{id}")]
        public IActionResult EditarComentarioPrestador(int id, [FromBody] EditarComentarioPrestadorDTO editDto)
        {
            try
            {
                _editarComentariosPrestador.EditarComentarioPrestador(editDto, id);
                return Ok(new { mensaje = "Comentario de prestador editado correctamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        /********************************************** COMENTARIOS SERVICIO ******************************************/


        //Alta comentario servicio
        [HttpPost("alta-comentario-servicio")]
        public ActionResult CreateComentarioServicio(AltaComentarioServicioDTO obj)
        {
            try
            {
                _altaComentarioServicio.AltaComentarioServicio(obj);
                return Ok(new { mensaje = "Comentario de servicio agregado correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Ocurrió un error inesperado: " + ex.Message });
            }
        }



        //Eliminar comentario servicio
        [HttpDelete("eliminar-comentario-servicio/{id}")]
        public IActionResult DeleteComentarioServicio(int id)
        {
            try
            {
                _eliminarComentarioServicio.Eliminar(id);
                return Ok(new { mensaje = "Comentario de servicio eliminado correctamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = $"No se pudo eliminar el comentario. Detalle: {ex.Message}" });
            }
        }



        //Editar comentario servicio
        [HttpPut("editar-comentario-servicio/{id}")]
        public IActionResult EditarComentarioServicio(int id, [FromBody] EditarComentarioServicioDTO editDto)
        {
            try
            {
                _editarComentariosServicio.EditarComentarioServicio(editDto, id);
                return Ok(new { mensaje = "Comentario de servicio editado correctamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }
    }
}
