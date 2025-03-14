using Compartido.DTOS.Comentarios.ComentariosPrestador;
using Compartido.DTOS.Prestador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfaceCU.Comentarios.ComentariosPrestador
{
    public interface IEditarComentariosPrestador
    {

        public void EditarComentarioPrestador(EditarComentarioPrestadorDTO DTO, int idComentario);


    }
}
