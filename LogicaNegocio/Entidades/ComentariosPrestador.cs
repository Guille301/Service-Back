using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class ComentariosPrestador
    {
        private object value;

        public int Id { get; set; }
        public string Contenido { get; set; }
        public int Estrellas { get; set; }
        public DateTime Fecha { get; set; }

        // Relación con Prestador
        public int PrestadorId { get; set; }
        public Prestador Prestador { get; set; }

        //Relacion con cliente
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }


        public string NombreCliente { get; set; }



        public ComentariosPrestador()
        {
            
        }

        public ComentariosPrestador(string contenido, int estrellas, DateTime fecha, int prestadorId, Prestador prestador, int clienteId, Cliente cliente)
        {
            Contenido = contenido;
            Estrellas = estrellas;
            Fecha = fecha;
            PrestadorId = prestadorId;
            Prestador = prestador;
            ClienteId = clienteId;
            Cliente = cliente;
        }

        public ComentariosPrestador(string contenido, int estrellas, object value)
        {
            Contenido = contenido;
            Estrellas = estrellas;
            this.value = value;
        }

        public ComentariosPrestador(string contenido, int estrellas,int id)
        {
            Contenido = contenido;
            Estrellas = estrellas;
            Id = id;

        }
    }
}
