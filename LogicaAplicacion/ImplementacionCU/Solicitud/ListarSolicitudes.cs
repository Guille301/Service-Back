using Compartido.DTOS.Solicitud;
using Compartido.Mappers;
using LogicaAplicacion.InterfaceCU.Solicitud;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCU.Solicitud
{
    public class ListarSolicitudes : IListarSolicitudes
    {

        private readonly IRepositorioSolicitud _repo;


        public ListarSolicitudes(IRepositorioSolicitud repo)
        {
            _repo = repo;

        }



        public List<ListarSolicitudesDePrestadorDTO> MostarSolicitudesDelPrestador(int id)
        {

            var servicio = _repo.SolicitudesPorPrestador(id);

            var servicioDTO = SolicitudMapper.FromListarSolicitudes(servicio);

            return servicioDTO;
        }





    }
}
