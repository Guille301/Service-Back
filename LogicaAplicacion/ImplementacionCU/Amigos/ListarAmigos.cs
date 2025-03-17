using Compartido.DTOS.Amigos;
using Compartido.Mappers;
using LogicaAplicacion.InterfaceCU.AmigosInterface;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCU.Amigos
{
    public class ListarAmigos : IListarAmigos
    {



        private readonly IRepositorioClienteAmigos _repo;


        public ListarAmigos(IRepositorioClienteAmigos repoClienteAmigo)
        {
            _repo = repoClienteAmigo;

        }




        public IEnumerable<ListarAmigosDTO> ListarLosAmigosPropios(int id)
        {
            var ami = _repo.ListarAmigosPropios(id);

            var amiDTO = ami.Select(p => AmigoMappers.FromListarAmigosCliente(p));

            return amiDTO;
        }










    }
}
