using Compartido.DTOS.Cliente;
using LogicaAplicacion.InterfaceCU.Cliente;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {


        private readonly IAltaCliente _altaCliente;
        private readonly IListarClienteBuscado _clienteBuscador;
        private readonly IEditarCliente _editarCliente;
        private readonly IEliminarCliente _eliminarCliente;
        private readonly IPerfilCliente _perfilCliente;



        public ClienteController(IAltaCliente Altacliente, IListarClienteBuscado clienteBuscador,IEditarCliente editCliente, IEliminarCliente eliminarCliente,IPerfilCliente perfilCliente)
        {
            _altaCliente = Altacliente;
            _clienteBuscador = clienteBuscador;
            _editarCliente = editCliente;
            _eliminarCliente = eliminarCliente;
            _perfilCliente = perfilCliente;
        }




        /*Alta*/
        [HttpPost]
        public IActionResult Create([FromBody] ClienteAltaDTO CliDto)
        {
            try
            {
                _altaCliente.Ejecutar(CliDto);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Ocurrió un error inesperado: " + ex.Message });
            }
        }

        [HttpGet("Cliente Buscador")]
        public IActionResult GetBuscador()
        {
            try
            {
                var atletas = _clienteBuscador.Ejecutar();
                return Ok(atletas);
            }
            catch (Exception ex)
            {
                return NotFound(new { mensaje = ex.Message });
            }
        }


        // Editar
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EditarClienteDto editDto)
        {
            try 
            {
                _editarCliente.EditarCliente(editDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }


        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            try
            {
                _eliminarCliente.Ejecutar(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = $"No se pudo eliminar el cliente. Detalle: {ex.Message}" });
            }



        }


        [HttpGet("MostrarPerfil{id}")]
        public IActionResult MostrarPerfil(int id)
        {
            try
            {
                var cliente = _perfilCliente.MostarDatos(id);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return NotFound(new { mensaje = ex.Message });
            }
        }












    

      

       
    }
}
