using Compartido.DTOS.Prestador;

using Compartido.DTOS.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfaceCU.Prestador
{
    public interface IListarPrestadorBuscador
    {

        IEnumerable<ListarPrestadorBuscadorDto> Ejecutar();


    }
}
