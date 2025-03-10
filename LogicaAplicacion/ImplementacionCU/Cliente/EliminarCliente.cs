using LogicaAplicacion.InterfaceCU.Cliente;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCU.Cliente
{
    public class EliminarCliente : IEliminarCliente
    {

        private readonly IRepositorioCliente _repositorioCliente;


        public EliminarCliente(IRepositorioCliente repoCliente)
        {
            _repositorioCliente = repoCliente;
        }


        public void Ejecutar(int id)
        {
            try
            {

                _repositorioCliente.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el cliente.", ex);
            }
        }






    }
}
