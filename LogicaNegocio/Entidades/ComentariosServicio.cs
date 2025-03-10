using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class ComentariosServicio
    {
        public int Id { get; set; }
        public string Contenido { get; set; }
        public int Estrellas { get; set; }
        public DateTime Fecha { get; set; }

        // Relación con cliente (autor del comentario)
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        // Relación con servicio o prestador (comentario asociado)
        public int? ServicioId { get; set; }
        public Servicio Servicio { get; set; }


        public string NombreCliente { get; set; }

        public ComentariosServicio()
        {
            
        }

        public ComentariosServicio(string contenido, int estrellas, DateTime fecha, int clienteId, Cliente cliente, int? servicioId, Servicio servicio)
        {
            Contenido = contenido;
            Estrellas = estrellas;
            Fecha = fecha;
            ClienteId = clienteId;
            Cliente = cliente;
            ServicioId = servicioId;
            Servicio = servicio;
        }

        public ComentariosServicio(string contenido, int estrellas, int id)
        {
            Contenido = contenido;
            Estrellas = estrellas;
            Id = id;
        }
    }
}
