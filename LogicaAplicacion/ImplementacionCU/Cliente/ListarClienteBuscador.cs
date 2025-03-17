using Compartido.DTOS.Cliente;
using Compartido.Mappers;
using LogicaAplicacion.InterfaceCU.Cliente;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCU.Cliente
{
    public class ListarClienteBuscador : IListarClienteBuscado
    {


        private readonly IRepositorioCliente _repositorioCliente;


        public ListarClienteBuscador(IRepositorioCliente repoCliente)
        {
            _repositorioCliente = repoCliente;

        }

        public IEnumerable<ListarClientesBuscador> Ejecutar(string criterio)
        {

            var Clientes = _repositorioCliente.BuscarClientes(criterio);

            var clientesDto = Clientes.Select(d => ClienteMappers.FromListarClientesBuscador(d));

            return clientesDto;
        }









    }
}
