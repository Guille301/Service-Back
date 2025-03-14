using Compartido.DTOS.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfaceCU.Cliente
{
    public interface IEditarCliente
    {

        public void EditarCliente(EditarClienteDto ClienteAltaDTO);



    }
}
