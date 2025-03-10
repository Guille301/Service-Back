using Compartido.DTOS.Cliente;
using Compartido.DTOS.Prestador;
using Compartido.DTOS.ServicioContratado;
using Compartido.DTOS.Solicitud;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOS.Mappers
{
    public class ServicioContratadoMappers
    {

        //Listar servicios contratados por prestador

        public static List<ListarServiciosContratadosPrestadorDTO> FromServicioContratadoListarPrestador(IEnumerable<LogicaNegocio.Entidades.ServicioContratado> Dto)
        {
            return Dto.Select(cli => new ListarServiciosContratadosPrestadorDTO
            {
                ClienteId = cli.ClienteId,
                ServicioId = cli.ServicioId,
                FechaHora = cli.FechaHora,  
                Lugar = cli.Lugar,  
                Datos = cli.Datos,
                Estado = cli.Estado

            }).ToList();
        }



        //Servicios contratados por cliente
        public static List<ListarServiciosContratadosClienteDTO> FromServicioContratadoListarCliente(IEnumerable<LogicaNegocio.Entidades.ServicioContratado> Dto)
        {
            return Dto.Select(cli => new ListarServiciosContratadosClienteDTO
            {
                ClienteId = cli.ClienteId,
                ServicioId = cli.ServicioId,
                FechaHora = cli.FechaHora,
                Lugar = cli.Lugar,
                Datos = cli.Datos,
                Estado = cli.Estado

            }).ToList();
        }




    }
}
