using Compartido.DTOS.Cliente;
using Compartido.DTOS.Prestador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfaceCU.Cliente
{
    public interface IPerfilCliente
    {

        PerfilClienteDTO MostarDatos(int id);



    }
}
