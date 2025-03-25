using Compartido.DTOS.Servicio;
using LogicaAplicacion.ImplementacionCU.Servicio;
using LogicaAplicacion.InterfaceCU.Servicio;
using LogicaAplicacion.InterfaceCU.Servicio.IListadoInicioFijo;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {

        private readonly IAltaServicio _altaServicio;
        private readonly IEditarServicio _editarServicio;
        private readonly IEliminarServicio _eliminarServicio;
        private readonly IFiltrarServicio _filtroServicio;
        private readonly IListarServicioCompleto _listarServicioCompleto;



        //Listado fijo
        private readonly IListarBelleza _listarBelleza;
        private readonly IListarReparaciones _listarReparaciones;
        private readonly IListarMecanico _listarMecanico;



        public ServicioController(IAltaServicio AltaServicio, IEditarServicio editarServicio, IEliminarServicio eliminarServicio,
                                    IListarBelleza listarBelleza,IListarReparaciones listarReparaciones,IListarMecanico listarMecanico,  
                                    IFiltrarServicio filtrarServicio, IListarServicioCompleto listarServicioCompleto)
        {
            _altaServicio = AltaServicio;
            _editarServicio = editarServicio;
            _eliminarServicio = eliminarServicio;
            _listarBelleza = listarBelleza;
            _listarReparaciones = listarReparaciones;
            _listarMecanico = listarMecanico;
            _filtroServicio = filtrarServicio;
            _listarServicioCompleto = listarServicioCompleto;
        }



        /*ALTA*/
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(ServicioAltaDto obj)
        {
            try
            {
                _altaServicio.AltaServicio(obj);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Ocurrió un error inesperado: " + ex.Message });
            }
        }


       
        /*EDITAR*/
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EditarServicioDto editDto)
        {
            try
            {
                _editarServicio.EditarServicio(editDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        /*ELIMINAR*/
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            try
            {
                _eliminarServicio.Ejecutar(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = $"No se pudo eliminar el cliente. Detalle: {ex.Message}" });
            }



        }


        /*********Listados fijos ********/
        //Listar belleza
        [HttpGet("ListarBelleza")]
        public IActionResult ListarBelleza()
        {
            try
            {
                var servicio = _listarBelleza.ListarServicioBelleza();
                return Ok(servicio);
            }
            catch (Exception ex)
            {
                return NotFound(new { mensaje = ex.Message });
            }
        }


        //Listar reparaciones
        [HttpGet("ListarReparaciones")]
        public IActionResult ListarReparaciones()
        {
            try
            {
                var servicio = _listarReparaciones.ListarServicioReparaciones();
                return Ok(servicio);
            }
            catch (Exception ex)
            {
                return NotFound(new { mensaje = ex.Message });
            }
        }


        //Listar mecanico
        [HttpGet("ListarMecanico")]
        public IActionResult ListarLegales()
        {
            try
            {
                var servicio = _listarMecanico.ListarServicioMecanico();
                return Ok(servicio);
            }
            catch (Exception ex)
            {
                return NotFound(new { mensaje = ex.Message });
            }
        }



        /*FILTRO*/
        [HttpGet("FiltroServicios")]
        public IActionResult FiltroDeServicio(int? precioMinimo, int? precioMaximo, string? descripcion, string? zona)
        {
            try
            {
                var servicio = _filtroServicio.FiltrarServicios(precioMinimo, precioMaximo, descripcion, zona);

                Console.WriteLine(servicio);

                return Ok(servicio);
            }
            catch (Exception ex)
            {
                return NotFound(new { ErroController = ex.Message });
            }
        }



        /*MOSTRAR TODOS LOS DATOS DEL SERVICIO*/


        [HttpGet("Mostrar todos los datos del servicio{id}")]
        public IActionResult MostrarDatosDelServicio(int id)
        {
            try
            {
                var servicios = _listarServicioCompleto.MostarTodosLosDatosDeServicio(id);
                return Ok(servicios);
            }
            catch (Exception ex)
            {
                return NotFound(new { mensaje = ex.Message });
            }
        }



















    }
}
