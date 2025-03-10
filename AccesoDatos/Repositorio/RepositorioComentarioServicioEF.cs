using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Repositorio
{
    public class RepositorioComentarioServicioEF : IRepositorioComentarioServicio
    {

        private LibreriaContext _db;
        public RepositorioComentarioServicioEF(LibreriaContext db)
        {
            _db = db;
        }

        //Alta
        public void Add(ComentariosServicio objeto)
        {
            try
            {
                _db.ComentariosServicio.Add(objeto);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el comentario", ex);
            }
        }

        //Eliminar
        public void Delete(int id)
        {
            var pre = _db.ComentariosServicio.Find(id);

            if (pre != null)
            {
                _db.ComentariosServicio.Remove(pre);
                _db.SaveChanges();
            }
            else
            {
                throw new Exception("comentario no encontrada");
            }
        }


        //Actualizar
        public void Update(ComentariosServicio objeto)
        {
            var ComentarioOriginal = _db.ComentariosServicio.Find(objeto.Id);
            try
            {
                ComentarioOriginal.Contenido = objeto.Contenido;
                ComentarioOriginal.Estrellas = objeto.Estrellas;


                _db.ComentariosServicio.Update(ComentarioOriginal);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el comentario", ex);
            }
        }

        public ComentariosServicio FindById(int id)
        {
            try
            {
                var usuario = _db.ComentariosServicio.Where(u => u.Id == id).FirstOrDefault();
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los prestadores", ex);
            }
        }




        public IEnumerable<ComentariosServicio> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ComentariosServicio> FindAllOrdenado()
        {
            throw new NotImplementedException();
        }

       
     
    }
}
