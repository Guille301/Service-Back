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
    public class RepositorioServicioEF : IRepositorioServicio
    {

        private LibreriaContext _db;
        public RepositorioServicioEF(LibreriaContext db)
        {
            _db = db;
        }



        public void Add(Servicio obj)
        {
            try
            {
                _db.Servicio.Add(obj);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el servicio", ex);
            }
        }

       

        public void Update(Servicio objeto)
        {
            var servicioOriginal = _db.Servicio.Find(objeto.Id);
            try
            {
                servicioOriginal.Nombre = objeto.Nombre;
                servicioOriginal.Precio = objeto.Precio;
                servicioOriginal.Descripcion = objeto.Descripcion;
                servicioOriginal.Categorias = objeto.Categorias;

                _db.Servicio.Update(servicioOriginal);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el servicio", ex);
            }
        }



        public void Delete(int id)
        {
            var pre = _db.Servicio.Find(id);

            if (pre != null)
            {
                _db.Servicio.Remove(pre);  
                _db.SaveChanges();  
            }
            else
            {
                throw new Exception("Servicio no encontrado");
            }
        }

        public IEnumerable<Servicio> FindAll()
        {
            try
            {
                return _db.Servicio.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los servicios", ex);
            }
        }



        //Buscador
        public IEnumerable<Servicio> BuscarServicios(string criterio)
        {
            try
            {
                return _db.Servicio
                         .Where(s => s.Nombre.Contains(criterio) || s.Descripcion.Contains(criterio) || s.Categorias.Contains(criterio))
                         .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar servicios", ex);
            }
        }



       
     

        //Voy a listar servicios de forma fija 

        public IEnumerable<Servicio> ObtenerServiciosBelleza()
        {
            try
            {
                return _db.Servicio
                         .Where(s => s.Categorias.Contains("Belleza")) // Filtrar por categoría
                         .Distinct() // Evitar duplicados
                         .Take(15) // Limitar a 15 registros
                         .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener servicios de Belleza", ex);
            }
        }

        public IEnumerable<Servicio> ObtenerServiciosReparaciones()
        {
            try
            {
                return _db.Servicio
                         .Where(s => s.Categorias.Contains("Reparaciones"))
                         .Distinct()
                         .Take(15)
                         .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener servicios de Reparaciones", ex);
            }
        }

        public IEnumerable<Servicio> ObtenerServiciosMecanicos()
        {
            try
            {
                return _db.Servicio
                         .Where(s => s.Categorias.Contains("mecanico"))
                         .Distinct()
                         .Take(15)
                         .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener servicios mecanicos", ex);
            }
        }


        //Filtro 
        public IEnumerable<Servicio> FiltroDeServicio(int? precioMinimo, int? precioMaximo , string? descripcion, string? zona)
        {


            try
            {
                IQueryable<Servicio> query = _db.Servicio
                            .Include(e => e.Prestador);

                if(precioMinimo !=null)
                {
                    query = query.Where(p => p.Precio >= precioMinimo);
                }

                if (precioMaximo != null)
                {
                    query = query.Where(p => p.Precio <= precioMaximo);
                }

                if (!string.IsNullOrWhiteSpace(descripcion))
                {
                    query = query.Where(e => e.Descripcion.ToLower().Contains(descripcion.ToLower()));
                }


                if (!string.IsNullOrWhiteSpace(zona))
                {
                    query = query.Where(p => p.Prestador.Barrio == zona);
                }


                return query.ToList();




            }
            catch (Exception ex)
            {
                throw new Exception("No se encontraron eventos para el filtro deseado", ex);

            }



        }

        //Mostrar datos completos del servicio

        public Servicio MostrarServicioCompleto(int id)
        {
            try
            {
                var ser = _db.Servicio
                               .Include(p => p.Prestador)
                               .Include(c => c.Comentarios)
                               .FirstOrDefault(u => u.Id == id);
                return ser;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los servicios", ex);
            }
        }








     

        public Servicio FindById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
