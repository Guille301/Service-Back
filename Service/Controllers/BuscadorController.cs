using LogicaAplicacion.InterfaceCU.BuscadorInterface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuscadorController : ControllerBase
    {


        private readonly IBuscador _buscadorCentralizado;

        public BuscadorController(IBuscador buscadorCentralizado)
        {
            _buscadorCentralizado = buscadorCentralizado;
        }


        [HttpGet]
        public IActionResult Buscar([FromQuery] string criterio)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(criterio))
                    return BadRequest(new { mensaje = "El criterio de búsqueda no puede estar vacío." });

                var resultados = _buscadorCentralizado.BuscarDatos(criterio);

                if (!resultados.Any())
                    return NotFound(new { mensaje = "No se encontraron resultados para el criterio especificado." });

                return Ok(resultados);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Ocurrió un error al realizar la búsqueda.", detalle = ex.Message });
            }
        }



        //// GET api/<BuscadorController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<BuscadorController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<BuscadorController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<BuscadorController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
