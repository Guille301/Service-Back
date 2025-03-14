using Compartido.DTOS.Comentarios.ComentariosPrestador;
using Compartido.DTOS.Comentarios.ComentariosServicios;
using Compartido.DTOS.Prestador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfaceCU.Comentarios.ComentariosServicios
{
    public interface IEditarComentariosServicio
    {

        public void EditarComentarioServicio(EditarComentarioServicioDTO DTO, int idComentario);


    }
}
