using LogicaAplicacion.InterfaceCU.Comentarios.ComentariosPrestador;
using LogicaAplicacion.InterfaceCU.Comentarios.ComentariosServicios;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCU.Comentarios.ComentariosServicios
{
    public class EliminarComentarioServicios : IEliminarComentarioServicio
    {


        private readonly IRepositorioComentarioServicio _repo;


        public EliminarComentarioServicios(IRepositorioComentarioServicio repo)
        {
            _repo = repo;

        }



        public void Eliminar(int id)
        {
            try
            {

                _repo.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar.", ex);
            }
        }






    }
}
