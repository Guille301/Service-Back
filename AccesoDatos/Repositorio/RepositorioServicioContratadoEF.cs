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
    public class RepositorioServicioContratadoEF : IRepositorioServicioContratado
    {
        private LibreriaContext _db;
        public RepositorioServicioContratadoEF(LibreriaContext db)
        {
            _db = db;
        }



        //Aqui traigo la lista de los servicios contratados del prestador
        public IEnumerable<ServicioContratado> ObtenerServiciosContratadosDePrestador(int id)
        {
            return _db.ServicioContratado
        .Include(sc => sc.Servicio) // Incluimos la relación con Servicio
        .ThenInclude(s => s.Prestador) // Incluimos la relación con Prestador
        .Where(sc => sc.Servicio.PrestadorId == id) // Filtramos por el ID del Prestador
        .ToList();
        }


        //Aqui traigo la lista de los servicios contratados del cliente

        public IEnumerable<ServicioContratado> ObtenerServiciosContratadosDeCliente(int id)
        {
            return _db.ServicioContratado
        .Include(sc => sc.Servicio) // Incluimos la relación con Servicio
        .Include(sc => sc.Cliente)  // Incluimos la relación con Cliente
        .Where(sc => sc.ClienteId == id) // Filtramos por el ID del Cliente
        .ToList();
        }

        //Con esto confirmo si el servicio se realizo o no 
        public void ServicioRealizadoONo(ServicioContratado objeto)
        {
            var Original = _db.ServicioContratado.Find(objeto.Id);
            try
            {
                Original.Estado = objeto.Estado;


                _db.ServicioContratado.Update(Original);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el servicio contratado", ex);
            }
        }






        public void Add(ServicioContratado obj)
        {
            try
            {
                _db.ServicioContratado.Add(obj);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el servicio contratado", ex);
            }

        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ServicioContratado> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ServicioContratado> FindAllOrdenado()
        {
            throw new NotImplementedException();
        }

        public ServicioContratado FindById(int id)
        {
            try
            {
                var ser = _db.ServicioContratado.Where(u => u.Id == id).FirstOrDefault();
                return ser;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los servicios contratados", ex);
            }
        }

       

        public void Update(ServicioContratado objeto)
        {
            throw new NotImplementedException();
        }

        
    }
}
