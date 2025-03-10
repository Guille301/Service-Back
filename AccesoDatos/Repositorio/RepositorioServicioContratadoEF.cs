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


        public IEnumerable<ServicioContratado> ObtenerServiciosContratadosDeCliente(int id)
        {
            return _db.ServicioContratado
        .Include(sc => sc.Servicio) // Incluimos la relación con Servicio
        .Include(sc => sc.Cliente)  // Incluimos la relación con Cliente
        .Where(sc => sc.ClienteId == id) // Filtramos por el ID del Cliente
        .ToList();
        }









        public void Add(ServicioContratado obj)
        {
            throw new NotImplementedException();

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
            throw new NotImplementedException();
        }

       

        public void Update(ServicioContratado objeto)
        {
            throw new NotImplementedException();
        }

       
    }
}
