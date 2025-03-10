using Compartido.DTOS.Cliente;
using Compartido.DTOS.Servicio;
using Compartido.DTOS.Solicitud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOS.Mappers
{
    public class SolicitudMapper
    {

        //Alta 
        public static LogicaNegocio.Entidades.Solicitud FromAltaSolicitud(AltaSolicitudDTO altaDto)
        {
            LogicaNegocio.Entidades.Solicitud solicitud = new LogicaNegocio.Entidades.Solicitud
            {
                IdCliente = altaDto.IdCliente,
                IdServicio = altaDto.IdServicio,
                FechaHora = altaDto.FechaHora,
                Lugar = altaDto.Lugar,
                Datos = altaDto.Datos,

            };

            return solicitud;
        }




        //Listar solicitudes por servicio
        public static List<ListarSolicitudesDePrestadorDTO> FromListarSolicitudes(IEnumerable<LogicaNegocio.Entidades.Solicitud> solicitudes)
        {
            return solicitudes.Select(cli => new ListarSolicitudesDePrestadorDTO
            {
                IdCliente = cli.IdCliente,
                IdServicio = cli.IdServicio,
                FechaHora = cli.FechaHora,
                Lugar = cli.Lugar,
                Datos = cli.Datos,
                Aprobado = cli.Aprobado
            }).ToList();
        }



        //Aprobar estado o no
        public static void ActualizarAprobacion(LogicaNegocio.Entidades.Solicitud solicitud, AprobarONoSolicitudDTO Dto)
        {
            solicitud.Aprobado = Dto.Aprobado;
        }






    }
}
