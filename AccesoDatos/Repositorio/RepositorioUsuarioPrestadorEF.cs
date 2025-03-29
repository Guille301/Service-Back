using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Repositorio
{
    public class RepositorioUsuarioPrestadorEF : IRepositorioUsuarioPrestador
    {

        private LibreriaContext _db;
        public RepositorioUsuarioPrestadorEF(LibreriaContext db)
        {
            _db = db;
        }





        public void Add(UsuarioPrestador objeto)
        {
            try
            {
                _db.UsuariosPrestadores.Add(objeto);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar al usuario prestador", ex);
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UsuarioPrestador> FindAll()
        {
            throw new NotImplementedException();
        }

        public UsuarioPrestador FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(UsuarioPrestador objeto)
        {
            throw new NotImplementedException();
        }
    }
}
