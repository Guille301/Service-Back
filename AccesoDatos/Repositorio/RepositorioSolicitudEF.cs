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
    public class RepositorioSolicitudEF : IRepositorioSolicitud
    {

        private LibreriaContext _db;
        public RepositorioSolicitudEF(LibreriaContext db)
        {
            _db = db;
        }


        //Alta
        public void Add(Solicitud objeto)
        {
            try
            {
                _db.Solicitud.Add(objeto);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar la solicitud", ex);
            }
        }


        //Delete
        public void Delete(int id)
        {
            var pre = _db.Solicitud.Find(id);

            if (pre != null)
            {
                _db.Solicitud.Remove(pre);
                _db.SaveChanges();
            }
            else
            {
                throw new Exception("Solicitud no encontrada");
            }
        }


        //Solicitudes por prestador
        public IEnumerable<Solicitud> SolicitudesPorPrestador(int idPrestador)
        {
            return _db.Solicitud
                   .Include(s => s.cliente)
                   .Include(s => s.servicio)
                   .ThenInclude(serv => serv.Prestador)   
                   .Where(s => s.servicio.PrestadorId == idPrestador)
                   .ToList();
        }




        //Aprobar o no la solicitud(activado o rechazado)
        public void AprobarONo(Solicitud objeto)
        {
            var Original = _db.Solicitud.Find(objeto.Id);
            try
            {
                Original.Aprobado = objeto.Aprobado;


                _db.Solicitud.Update(Original);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al aprobar la solicitud", ex);
            }
        }

        //Find by id
        public Solicitud FindById(int id)
        {
            try
            {
                var usuario = _db.Solicitud.Where(u => u.Id == id).FirstOrDefault();
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las solicitudes", ex);
            }
        }



        public IEnumerable<Solicitud> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Solicitud> FindAllOrdenado()
        {
            throw new NotImplementedException();
        }

     
       

        public void Update(Solicitud objeto)
        {
            throw new NotImplementedException();
        }





    }
}
