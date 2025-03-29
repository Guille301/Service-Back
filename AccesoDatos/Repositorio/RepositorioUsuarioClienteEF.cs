using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Repositorio
{
    public class RepositorioUsuarioClienteEF : IRepositorioUsuarioCliente
    {

        private LibreriaContext _db;
        public RepositorioUsuarioClienteEF(LibreriaContext db)
        {
            _db = db;
        }



        public void Add(UsuarioCliente objeto)
        {
            try
            {
                _db.UsuariosClientes.Add(objeto);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar al usuario cliente", ex);
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UsuarioCliente> FindAll()
        {
            throw new NotImplementedException();
        }

        public UsuarioCliente FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(UsuarioCliente objeto)
        {
            throw new NotImplementedException();
        }
    }
}
