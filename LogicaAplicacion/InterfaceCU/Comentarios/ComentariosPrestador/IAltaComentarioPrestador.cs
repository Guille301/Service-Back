using Compartido.DTOS.Cliente;
using Compartido.DTOS.Comentarios.ComentariosPrestador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfaceCU.Comentarios.ComentariosPrestador
{
    public interface IAltaComentarioPrestador
    {

        public void AltaComentarioPrestador(AltaComentarioPrestadorDTO altaDto);



    }
}
