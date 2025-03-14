using LogicaAplicacion.InterfaceCU.AmigosInterface;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCU.Amigos
{
    public class EliminarAmigos : IEliminarAmigos
    {




        private readonly IRepositorioClienteAmigos _repo;


        public EliminarAmigos(IRepositorioClienteAmigos repoClienteAmigo)
        {
            _repo = repoClienteAmigo;

        }

        void IEliminarAmigos.EliminarAmigos(int id)
        {
            try
            {

                _repo.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el amigo.", ex);
            }
        }






    }
}
