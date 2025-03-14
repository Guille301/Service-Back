using Compartido.Mappers;
using LogicaAplicacion.InterfaceCU.Prestador;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCU.Prestador
{
    public class ListarPrestadorBuscador : IListarPrestadorBuscador
    {
        private readonly IRepositorioPrestador _repositorioPrestador;

        public ListarPrestadorBuscador(IRepositorioPrestador repoPrestador)
        {
            _repositorioPrestador = repoPrestador;
        }

       

        IEnumerable<Compartido.DTOS.Prestador.ListarPrestadorBuscadorDto> IListarPrestadorBuscador.Ejecutar()
        {
            var prestadores = _repositorioPrestador.FindAll();

            var prestadoresDto = prestadores.Select(p => PrestadorMappers.FromPrestadorToListarPrestadorBuscador(p));

            return prestadoresDto;
        }
    }
}
