using Compartido.DTOS.Amigos;
using Compartido.Mappers;
using LogicaAplicacion.InterfaceCU.AmigosInterface;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCU.Amigos
{
    public class ListarAmigosRecomendados : IListarAmigosRecomendados
    {

        private readonly IRepositorioClienteAmigos _repo;


        public ListarAmigosRecomendados(IRepositorioClienteAmigos repoClienteAmigo)
        {
            _repo = repoClienteAmigo;

        }





        public IEnumerable<ListarAmigosRecomendadosDTO> ListarLosAmigosRecomendados(int id)
        {
            var ami = _repo.ListarAmigosRecomendados(id);

            var amiDTO = ami.Select(p => AmigoMappers.FromListarAmigosRecomendados(p));

            return amiDTO;
        }





    }
}
