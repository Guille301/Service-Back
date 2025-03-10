using Compartido.DTOS.Servicio;
using LogicaAplicacion.InterfaceCU.Prestador;
using LogicaAplicacion.InterfaceCU.Servicio;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCU.Servicio
{
    public class FiltrarServicio : IFiltrarServicio
    {


        private readonly IRepositorioServicio _repositorioServicio;


        public FiltrarServicio(IRepositorioServicio repoServicio)
        {
            _repositorioServicio = repoServicio;

        }


        IEnumerable<ListarServicioChico> IFiltrarServicio.FiltrarServicios(int? precioMinimo, int? precioMaximo, string? descripcion, string? zona)
        {
            var servicio = _repositorioServicio.FiltroDeServicio(precioMinimo, precioMaximo, descripcion, zona);

            var servicioDTO = servicio.Select(p => Compartido.DTOS.Mappers.ServicioMappers.FromServicioToListarServicioBuscador(p));


            return servicioDTO;
        }
    }
}
