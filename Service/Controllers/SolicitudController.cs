using Compartido.DTOS.Prestador;
using Compartido.DTOS.Servicio;
using Compartido.DTOS.Solicitud;
using LogicaAplicacion.InterfaceCU.Solicitud;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudController : ControllerBase
    {

        private readonly IAltaSolicitud _altaSolicitud;
        private readonly IEliminarSolicitud _eliminarSolicitud;
        private readonly IListarSolicitudes _listarSolicitudes;
        private readonly IAprobarSolicitud _aprobarSolicitud;



        public SolicitudController(IAltaSolicitud altaSolicitud,IEliminarSolicitud eliminarSolicitud,IListarSolicitudes listarSolicitudes, IAprobarSolicitud aprobarSolicitud)
        {
            _altaSolicitud = altaSolicitud;
            _eliminarSolicitud = eliminarSolicitud;
            _listarSolicitudes = listarSolicitudes;
            _aprobarSolicitud = aprobarSolicitud;

        }


        /*ALTA*/
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(AltaSolicitudDTO obj)
        {
            try
            {
                _altaSolicitud.Alta(obj);

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
                _eliminarSolicitud.Eliminar(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = $"No se pudo eliminar la solicitud. Detalle: {ex.Message}" });
            }



        }



        //Mostrar las solicitudes por prestador

        [HttpGet("Mostrar solicitudes del prestador")]
        public IActionResult MostrarSolicitudes(int idPrestador)
        {
            try
            {
                var prestadores = _listarSolicitudes.MostarSolicitudesDelPrestador(idPrestador);
                return Ok(prestadores);
            }
            catch (Exception ex)
            {
                return NotFound(new { mensaje = ex.Message });
            }
        }



        //Aprobar o no la solicitud
        [HttpPut("Aprobar solicitud{id}")]
        public IActionResult Put([FromBody] AprobarONoSolicitudDTO Dto)
        {
            try
            {
                _aprobarSolicitud.Aprobar(Dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }




    }
}
