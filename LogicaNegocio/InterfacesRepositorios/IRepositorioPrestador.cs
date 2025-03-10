using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioPrestador : IRepositorio<Prestador>
    {


        IEnumerable<Prestador> BuscarPrestadores(string criterio);

        public Prestador FindByEmail(string email);

        public Prestador MostrarPerfilPrestador(int id);





    }
}
