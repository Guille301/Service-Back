using Compartido.DTOS.Amigos;
using Compartido.DTOS.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfaceCU.AmigosInterface
{
    public interface IListarAmigos
    {



        IEnumerable<ListarAmigosDTO> ListarLosAmigosPropios(int id);








    }
}
