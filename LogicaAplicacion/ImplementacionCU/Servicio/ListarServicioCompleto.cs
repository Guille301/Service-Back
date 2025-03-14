using Compartido.DTOS.Servicio;
using Compartido.Mappers;
using LogicaAplicacion.InterfaceCU.Servicio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCU.Servicio
{
    public class ListarServicioCompleto : IListarServicioCompleto
    {

        private readonly IRepositorioServicio _repositorioServicio;


        public ListarServicioCompleto(IRepositorioServicio repoServicio)
        {
            _repositorioServicio = repoServicio;

        }

        public ListarTodosLosDatosServicioDTO MostarTodosLosDatosDeServicio(int id)
        {

            var servicio = _repositorioServicio.MostrarServicioCompleto(id);

            var servicioDTO = ServicioMappers.MostrarTodosLosDatosServicio(servicio);

            // Retornar el DTO
            return servicioDTO;
        }













    }
}
