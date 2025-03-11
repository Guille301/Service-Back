using Compartido.DTOS.Servicio;
using Compartido.DTOS.ServicioContratado;
using Compartido.DTOS.Solicitud;
using LogicaAplicacion.ImplementacionCU.Prestador;
using LogicaAplicacion.ImplementacionCU.ServicioContratado;
using LogicaAplicacion.InterfaceCU.Prestador;
using LogicaAplicacion.InterfaceCU.Servicio;
using LogicaAplicacion.InterfaceCU.ServicioContratado;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioContratadoController : ControllerBase
    {

        private readonly IListarSerContratadoPrestador _listarPrestador;
        private readonly IListarSerContratadoCliente _listarCliente;
        private readonly IConfirmarRealizacion _confirmarRealizacion;



        public ServicioContratadoController(IListarSerContratadoPrestador serContratadorPrestado, IListarSerContratadoCliente serContratadoCliente,IConfirmarRealizacion confirmarRealizacion)
        {

            _listarPrestador = serContratadorPrestado;
            _listarCliente = serContratadoCliente;
            _confirmarRealizacion = confirmarRealizacion;
            
        }



        [HttpGet("Mostrar servicios contratados prestador{id}")]
        public IActionResult MostrarServiciosContratadosPrestador(int id)
        {
            try
            {
                var prestadores = _listarPrestador.MostarServiciosContratados(id);
                return Ok(prestadores);
            }
            catch (Exception ex)
            {
                return NotFound(new { mensaje = ex.Message });
            }
        }


        [HttpGet("Mostrar servicios contratados cliente{id}")]
        public IActionResult MostrarServiciosContratadosCliente(int id)
        {
            try
            {
                var prestadores = _listarCliente.MostarServiciosContratadosCliente(id);
                return Ok(prestadores);
            }
            catch (Exception ex)
            {
                return NotFound(new { mensaje = ex.Message });
            }
        }



        //Confirmar realizacion
        [HttpPut("Confirmar realizacion del servicio{id}")]
        public IActionResult Put([FromBody] ServicioRealizadoDTO Dto)
        {
            try
            {
                _confirmarRealizacion.Realizado(Dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }








    }
}
