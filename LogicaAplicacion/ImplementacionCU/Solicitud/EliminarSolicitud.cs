using LogicaAplicacion.InterfaceCU.Solicitud;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCU.Solicitud
{
    public class EliminarSolicitud : IEliminarSolicitud
    {



        private readonly IRepositorioSolicitud _repo;


        public EliminarSolicitud(IRepositorioSolicitud repo)
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
                throw new Exception("Error al eliminar la solicitud.", ex);
            }
        }












    }
}
