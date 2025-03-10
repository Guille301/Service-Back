using Compartido.DTOS.Servicio;
using Compartido.DTOS.Solicitud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfaceCU.Solicitud
{
    public interface IListarSolicitudes
    {
        List<ListarSolicitudesDePrestadorDTO> MostarSolicitudesDelPrestador(int id);



    }
}
