using Compartido.DTOS.Buscador;
using LogicaAplicacion.InterfaceCU.BuscadorInterface;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCU.Buscador
{
    public class Buscador : IBuscador
    {
        
        private readonly IRepositorioServicio _repoServicio;
        private readonly IRepositorioPrestador _repoPrestador;

        public Buscador(
            
            IRepositorioServicio repoServicio,
            IRepositorioPrestador repoPrestador)
        {
            _repoServicio = repoServicio;
            _repoPrestador = repoPrestador;
        }

        public IEnumerable<ResultadoBusquedaDto> BuscarDatos(string criterio)
        {
            // Consultar cada repositorio y convertir los resultados a un formato unificado
          

            var servicios = _repoServicio.BuscarServicios(criterio).Select(s => new ResultadoBusquedaDto
            {
                Nombre = s.Nombre,
                Tipo = "Servicio",
                Descripcion = s.Descripcion,
                Foto = s.ImagenesDeTrabajosSimilares,

            });

            var prestadores = _repoPrestador.BuscarPrestadores(criterio).Select(p => new ResultadoBusquedaDto
            {
                Nombre = p.Nombre,
                Tipo = "Prestador",
                Descripcion = p.Descripcion,
                Foto = p.FotoPerfil,

            });

            // Unificar los resultados en una lista única
            return servicios.Concat(prestadores);
        }




    }
}
