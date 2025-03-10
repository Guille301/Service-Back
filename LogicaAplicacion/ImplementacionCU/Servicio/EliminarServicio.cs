using LogicaAplicacion.InterfaceCU.Servicio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCU.Servicio
{
    public class EliminarServicio : IEliminarServicio
    {
        private readonly IRepositorioServicio _repositorioServicio;

        public EliminarServicio(IRepositorioServicio repoServicio)
        {
            _repositorioServicio = repoServicio;
        }


        public void Ejecutar(int id)
        {
            try
            {

                _repositorioServicio.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la solicitud.", ex);
            }
        }

    }
}
