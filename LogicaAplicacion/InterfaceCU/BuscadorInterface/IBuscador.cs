using Compartido.DTOS.Buscador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfaceCU.BuscadorInterface
{
    public interface IBuscador
    {

        IEnumerable<ResultadoBusquedaDto> BuscarDatos(string criterio);


    }
}
