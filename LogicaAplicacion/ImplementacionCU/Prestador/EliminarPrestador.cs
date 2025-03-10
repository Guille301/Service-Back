using LogicaAplicacion.InterfaceCU.Prestador;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCU.Prestador
{
    public class EliminarPrestador : IEliminarPrestador
    {

        private readonly IRepositorioPrestador _repositorioPrestador;

        public EliminarPrestador(IRepositorioPrestador repoPrestador)
        {
            _repositorioPrestador = repoPrestador;
        }


        public void Ejecutar(int id)
        {
            try
            {

                _repositorioPrestador.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la disciplina.", ex);
            }
        }
    }
}
