using LogicaAplicacion.InterfaceCU.Comentarios.ComentariosPrestador;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCU.Comentarios.ComentariosPrestador
{
    public class EliminarComentarioPrestador : IEliminarComentarioPrestador
    {


        private readonly IRepositorioComentarioPrestador _repositorioComentarioPrestador;


        public EliminarComentarioPrestador(IRepositorioComentarioPrestador repo)
        {
            _repositorioComentarioPrestador = repo;

        }



        public void Eliminar(int id)
        {
            try
            {

                _repositorioComentarioPrestador.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar.", ex);
            }
        }






    }
}
