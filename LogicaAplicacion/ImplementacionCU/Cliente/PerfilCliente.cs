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
    public class PerfilCliente : IPerfilCliente
    {

        private readonly IRepositorioCliente _repositorioCliente;


        public PerfilCliente(IRepositorioCliente repoCliente)
        {
            _repositorioCliente = repoCliente;
        }

        public PerfilClienteDTO MostarDatos(int id)
        {
            var prestador = _repositorioCliente.FindById(id);

            var prestadorDto = ClienteMappers.PerfilCliente(prestador);

            return prestadorDto;
        }

    

    }
}
