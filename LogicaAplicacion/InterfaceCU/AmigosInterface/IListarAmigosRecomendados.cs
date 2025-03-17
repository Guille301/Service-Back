using Compartido.DTOS.Amigos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfaceCU.AmigosInterface
{
    public interface IListarAmigosRecomendados
    {
        IEnumerable<ListarAmigosRecomendadosDTO> ListarLosAmigosRecomendados(int id);







    }
}
