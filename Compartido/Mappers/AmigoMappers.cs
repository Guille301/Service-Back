using Compartido.DTOS.Amigos;
using Compartido.DTOS.Cliente;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.Mappers
{
    public class AmigoMappers
    {

        //Listar amigos propios

        public static ListarAmigosDTO FromListarAmigosCliente(ClienteAmigo cli)
        {
            return new ListarAmigosDTO
            {
                AmigoId = cli.AmigoId
            };
        }


        public static ListarAmigosRecomendadosDTO FromListarAmigosRecomendados(ClienteAmigo cli)
        {
            return new ListarAmigosRecomendadosDTO
            {
                AmigoId = cli.AmigoId
            };
        }





    }
}
