using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Repositorio
{
    public class RepositorioPrestadorEF : IRepositorioPrestador
    {

        private LibreriaContext _db;
        public RepositorioPrestadorEF(LibreriaContext db)
        {
            _db = db;
        }

        public void Add(Prestador obj)
        {
            using var transaction = _db.Database.BeginTransaction();
            try
            {
                _db.Prestador.Add(obj);
                _db.SaveChanges();

                var usuarioPrestador = new UsuarioPrestador
                {
                    Email = obj.Email,
                    PasswordHash = obj.PasswordHash,
                    FechaCreacion = DateTime.UtcNow,
                    PrestadorId = obj.Id
                };

                _db.UsuariosPrestadores.Add(usuarioPrestador);
                _db.SaveChanges();

                transaction.Commit();

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception("Error al agregar el prestador", ex);
            }
        }

        public void Delete(int id)
        {

            var pre = _db.Prestador.Find(id);

            if (pre != null)
            {
                _db.Prestador.Remove(pre);  
                _db.SaveChanges();  
            }
            else
            {
                throw new Exception("Prestador no encontrado");
            }



        }

        public IEnumerable<Prestador> FindAll()
        {
            try
            {
                return _db.Prestador.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los prestadores", ex);
            }
        }


        public void Update(Prestador objeto)
        {
            var prestadorOriginal = _db.Prestador.Find(objeto.Id);
            try
            {
                prestadorOriginal.Nombre = objeto.Nombre;
                prestadorOriginal.Email = objeto.Email;
                prestadorOriginal.Celular = objeto.Celular;
                prestadorOriginal.Ciudad = objeto.Ciudad;
                prestadorOriginal.Barrio = objeto.Barrio;
                prestadorOriginal.Descripcion = objeto.Descripcion;


                // Actualizar la contraseña solo si se proporciona una nueva
                if (!string.IsNullOrEmpty(objeto.PasswordHash))
                {
                    prestadorOriginal.SetPassword(objeto.PasswordHash);
                }


                _db.Prestador.Update(prestadorOriginal);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el prestador", ex);
            }
        }


      

        public Prestador FindById(int id)
        {
            try
            {
                var usuario = _db.Prestador.Where(u => u.Id == id).FirstOrDefault();
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los prestadores", ex);
            }
        }

        //Mostrar perfil de prestador
        public Prestador MostrarPerfilPrestador(int id)
        {
            try
            {
                var usuario = _db.Prestador
                               .Include(p => p.Servicios)
                               .Include(c => c.Comentarios)
                               .FirstOrDefault(u => u.Id == id);
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los prestadores", ex);
            }
        }


        //Buscador
        public IEnumerable<Prestador> BuscarPrestadores(string criterio)
        {
            try
            {
                return _db.Prestador
                         .Where(p => p.Nombre.Contains(criterio) || p.Descripcion.Contains(criterio))
                         .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar prestadores", ex);
            }
        }



        //Find by email
        public Prestador FindByEmail(string email)
        {
            try
            {
                var usuario = _db.Prestador.Where(u => u.Email == email).FirstOrDefault();
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los clientes", ex);
            }
        }



     




    }
}
