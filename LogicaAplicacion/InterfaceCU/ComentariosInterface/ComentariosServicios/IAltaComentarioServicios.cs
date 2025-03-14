using Compartido.DTOS.Cliente;
using Compartido.DTOS.Comentarios.ComentariosPrestador;
using Compartido.DTOS.Comentarios.ComentariosServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfaceCU.Comentarios.ComentariosServicios
{
    public interface IAltaComentarioServicios
    {

        public void AltaComentarioServicio(AltaComentarioServicioDTO altaDto);



    }
}
