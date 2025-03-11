using Compartido.DTOS.Mappers;
using Compartido.DTOS.Prestador;
using Compartido.DTOS.Solicitud;
using LogicaAplicacion.InterfaceCU.Solicitud;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.Entidades;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCU.Solicitud
{
    public class AprobarSolicitud : IAprobarSolicitud
    {


        private readonly IRepositorioSolicitud _repo;
        private readonly IRepositorioServicioContratado _repositorioServicioContratado;


        public AprobarSolicitud(IRepositorioSolicitud repo, IRepositorioServicioContratado repoServicio)
        {
            _repo = repo;
            _repositorioServicioContratado = repoServicio;


        }




        public void Aprobar(AprobarONoSolicitudDTO DTO)
        {

            try
            {
                var solicitudBuscada = _repo.FindById(DTO.Id);

                if (solicitudBuscada == null)
                {
                    throw new Exception("Solicitud no encontrada.");
                }

                SolicitudMapper.ActualizarAprobacion(solicitudBuscada, DTO);

                _repo.AprobarONo(solicitudBuscada);


                // Si la solicitud fue aprobada, crear un ServicioContratado
                if (DTO.Aprobado == true)
                {
                    var servicioContratado = new LogicaNegocio.Entidades.ServicioContratado
                    {
                        ClienteId = solicitudBuscada.IdCliente,
                        ServicioId = solicitudBuscada.IdServicio,
                        FechaHora = solicitudBuscada.FechaHora,
                        Lugar = solicitudBuscada.Lugar,
                        Datos = solicitudBuscada.Datos,
                        Estado = null
                    };

                    _repositorioServicioContratado.Add(servicioContratado);
                }


            }
            catch (Exception ex)
            {
                throw new Exception($"Error en Aprobar: {ex.Message}");
            }
        }




    }
}
