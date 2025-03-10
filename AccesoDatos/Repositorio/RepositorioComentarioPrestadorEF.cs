using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Repositorio
{
    public class RepositorioComentarioPrestadorEF : IRepositorioComentarioPrestador
    {
        private LibreriaContext _db;
        public RepositorioComentarioPrestadorEF(LibreriaContext db)
        {
            _db = db;
        }



        //Alta
        public void Add(ComentariosPrestador objeto)
        {
            try
            {
                _db.ComentariosPrestador.Add(objeto);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el cliente", ex);
            }
        }


        //Eliminar
        public void Delete(int id)
        {
            var pre = _db.ComentariosPrestador.Find(id);

            if (pre != null)
            {
                _db.ComentariosPrestador.Remove(pre);
                _db.SaveChanges();
            }
            else
            {
                throw new Exception("comentario no encontrada");
            }
        }


        //Modificar comentario
        public void Update(ComentariosPrestador objeto)
        {
            var ComentarioOriginal = _db.ComentariosPrestador.Find(objeto.Id);
            try
            {
                ComentarioOriginal.Contenido = objeto.Contenido;
                ComentarioOriginal.Estrellas = objeto.Estrellas;


                _db.ComentariosPrestador.Update(ComentarioOriginal);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el comentario", ex);
            }
        }

        public IEnumerable<ComentariosPrestador> FindAll()
        {
            throw new NotImplementedException();
        }
         
        public IEnumerable<ComentariosPrestador> FindAllOrdenado()
        {
            throw new NotImplementedException();
        }

        public ComentariosPrestador FindById(int id)
        {
            try
            {
                var usuario = _db.ComentariosPrestador.Where(u => u.Id == id).FirstOrDefault();
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los prestadores", ex);
            }
        }

      
    }
}
