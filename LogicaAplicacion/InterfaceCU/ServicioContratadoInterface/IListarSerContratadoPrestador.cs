using Compartido.DTOS.Servicio;
using Compartido.DTOS.ServicioContratado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfaceCU.ServicioContratado
{
    public interface IListarSerContratadoPrestador
    {

        List<ListarServiciosContratadosPrestadorDTO> MostarServiciosContratados(int id);


    }
}
