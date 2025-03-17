using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioClienteAmigos : IRepositorio<ClienteAmigo>
    {

        public IEnumerable<ClienteAmigo> ListarAmigosPropios(int IdAmigos);


        public IEnumerable<ClienteAmigo> ListarAmigosRecomendados(int clienteId);


        public void AddAmistadBidireccional(int clienteId, int amigoId);



    }
}
