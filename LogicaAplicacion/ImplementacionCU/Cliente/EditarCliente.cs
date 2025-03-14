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
    public class EditarCliente : IEditarCliente
    {
        private readonly IRepositorioCliente _repositorioCliente;


        public EditarCliente(IRepositorioCliente repoCliente)
        {
            _repositorioCliente = repoCliente;
        }

        void IEditarCliente.EditarCliente(EditarClienteDto ClienteAltaDTO)
        {

            try
            {

                LogicaNegocio.Entidades.Cliente Dis = ClienteMappers.FromEditarClienteDto(ClienteAltaDTO);

                _repositorioCliente.Update(Dis);
            }
          
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }





    }
}
