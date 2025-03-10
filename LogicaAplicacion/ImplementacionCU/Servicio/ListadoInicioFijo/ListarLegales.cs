using Compartido.DTOS.Servicio;
using LogicaAplicacion.InterfaceCU.Servicio.IListadoInicioFijo;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCU.Servicio.ListadoInicioFijo
{
    public class ListarLegales : IListarLegales
    {

        private readonly IRepositorioServicio _repositorioServicio;


        public ListarLegales(IRepositorioServicio repoServicio)
        {
            _repositorioServicio = repoServicio;

        }



        public IEnumerable<ListarServicioChico> ListarServicioLegales()
        {
            var servicio = _repositorioServicio.ObtenerServiciosBelleza();

            var servicioDTO = servicio.Select(d => Compartido.DTOS.Mappers.ServicioMappers.FromServicioToListarServicioBuscador(d));

            return servicioDTO;
        }





    }
}
