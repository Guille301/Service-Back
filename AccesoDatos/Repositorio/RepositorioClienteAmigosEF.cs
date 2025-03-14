using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Repositorio
{
    public class RepositorioClienteAmigosEF : IRepositorioClienteAmigos
    {

        private LibreriaContext _db;
        public RepositorioClienteAmigosEF(LibreriaContext db)
        {
            _db = db;
        }


        
        public void Add(ClienteAmigo objeto)
        {
            try
            {


                _db.ClienteAmigo.Add(objeto);
                _db.SaveChanges();



            }
            catch (Exception ex)
            {

                throw new Exception("Error al agregar el amigo", ex);

            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClienteAmigo> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClienteAmigo> FindAllOrdenado()
        {
            throw new NotImplementedException();
        }

        public ClienteAmigo FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ClienteAmigo objeto)
        {
            throw new NotImplementedException();
        }

      
    }
}
