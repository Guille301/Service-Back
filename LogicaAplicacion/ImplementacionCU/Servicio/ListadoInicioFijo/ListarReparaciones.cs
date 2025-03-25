using Compartido.DTOS.Servicio;
using Compartido.Mappers;
using LogicaAplicacion.InterfaceCU.Servicio.IListadoInicioFijo;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCU.Servicio.ListadoInicioFijo
{
    public class ListarReparaciones : IListarReparaciones
    {


        private readonly IRepositorioServicio _repositorioServicio;


        public ListarReparaciones(IRepositorioServicio repoServicio)
        {
            _repositorioServicio = repoServicio;

        }



        public IEnumerable<ListarServicioChico> ListarServicioReparaciones()
        {
            var servicio = _repositorioServicio.ObtenerServiciosReparaciones();

            var servicioDTO = servicio.Select(d => ServicioMappers.FromServicioToListarServicioChico(d));

            return servicioDTO;
        }



    }
}
