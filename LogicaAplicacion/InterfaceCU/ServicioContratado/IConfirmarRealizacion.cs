using Compartido.DTOS.ServicioContratado;
using Compartido.DTOS.Solicitud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfaceCU.ServicioContratado
{
    public interface IConfirmarRealizacion
    {

        public void Realizado(ServicioRealizadoDTO DTO);



    }
}
